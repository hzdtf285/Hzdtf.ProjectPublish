using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hzdtf.Utility.Utils;
using Hzdtf.PublishProject.Model.Server;
using Hzdtf.PublishProject.Model.Project;
using Hzdtf.ProjectPublish.FTP;
using Hzdtf.ProjectPublish.File;
using Hzdtf.ProjectPublish.Remote.Contract;
using Hzdtf.ProjectPublish.Model.Remote;
using System.Diagnostics;
using Hzdtf.ProjectPublish.Service.Contract;
using Hzdtf.ProjectPublish.Service.Impl;
using Hzdtf.ProjectPublish.Model.Publish;

namespace Hzdtf.ProjectPublish.WinForm
{
    /// <summary>
    /// 主界面
    /// @ 黄振东
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// 服务器数据
        /// </summary>
        private readonly ServerInfo serverData;

        /// <summary>
        /// 项目数据
        /// </summary>
        private readonly ProjectInfo projectData;

        /// <summary>
        /// 项目部署数据
        /// </summary>
        private readonly ProjectDeployInfo projectDeployData;

        /// <summary>
        /// 项目映射是否选中字典，key：物理机ID，value：是否选中
        /// </summary>
        private readonly IDictionary<int, bool> dicProjectMapSelected = new Dictionary<int, bool>();

        /// <summary>
        /// 远程方式数据
        /// </summary>
        private readonly RemoteWayInfo[] remoteWayData = new RemoteWayInfo[]
        {
            new RemoteWayInfo()
            {
                Id = 1,
                Name = "FTP"
            }
        };

        /// <summary>
        /// 环境变量组
        /// </summary>
        private IDictionary<string, IDictionary<string, string>> enviVarGroups;

        /// <summary>
        /// 主服务
        /// </summary>
        private readonly IPublishService service = new PublishService();

        /// <summary>
        /// 构造方法
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            var configFactory = new JsonConfigFactory();
            var reader = configFactory.CreateServerReader();

            serverData = configFactory.CreateServerReader().Reader();
            projectData = configFactory.CreateProjectReader().Reader();
            projectDeployData = configFactory.CreateProjectDeployReader().Reader();
            enviVarGroups = configFactory.CreateEnviVarGroupReader().Reader();
        }

        /// <summary>
        /// 界面加载时触发
        /// </summary>
        /// <param name="sender">引发对象</param>
        /// <param name="e">事件参数</param>
        private void Main_Load(object sender, EventArgs e)
        {
            dgvProject.AutoGenerateColumns = false;
            dgvMachine.AutoGenerateColumns = false;

            BindServerData();
            BindRemoteWayData();
            BindEnviVarGroupData();
        }

        /// <summary>
        /// 绑定服务器数据
        /// </summary>
        private void BindServerData()
        {
            cbxServer.DataSource = null;
            if (serverData == null || serverData.Servers.IsNullOrLength0())
            {
                return;
            }
            cbxServer.DataSource = serverData.Servers;
        }

        /// <summary>
        /// 绑定远程方式数据
        /// </summary>
        private void BindRemoteWayData()
        {
            cbxRemoteWay.DataSource = remoteWayData;
        }

        /// <summary>
        /// 绑定环境变量组数据
        /// </summary>
        private void BindEnviVarGroupData()
        {
            if (enviVarGroups.IsNullOrCount0())
            {
                return;
            }
            ddlEnviVar.Items.AddRange(enviVarGroups.Select(p => p.Key).ToArray());
            ddlEnviVar.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定项目数据
        /// </summary>
        /// <param name="serverId">服务器ID</param>
        private void BindProjectData(int serverId)
        {
            dicProjectMapSelected.Clear();
            dgvProject.DataSource = null;
            cbxAllProject.Checked = false;
            var projects = projectDeployData.GetProjectsByServerId(projectData, serverId);
            foreach (var item in projects)
            {
                dicProjectMapSelected.Add(item.ProjectId, item.Selected);
            }

            dgvProject.DataSource = projects;
        }

        /// <summary>
        /// 绑定物理机数据
        /// </summary>
        /// <param name="machines">物理机数组</param>
        private void BindMachineData(ServerInfo.Machine[] machines = null)
        {
            if (dgvMachine.InvokeRequired)
            {
                dgvMachine.BeginInvoke(new Action<ServerInfo.Machine[]>(BindMachineData), new object[] { machines });
                return;
            }

            if (machines == null)
            {
                dgvMachine.DataSource = null;
                var server = cbxServer.SelectedItem as ServerInfo.Server;
                ProjectInfo.Project[] allProj;
                var projects = GetSelectDataGridData<ProjectInfo.Project>(dgvProject, (p, isSelect) =>
                {
                    p.Selected = isSelect;
                }, out allProj);
                if (projects.IsNullOrLength0())
                {
                    return;
                }

                dgvMachine.DataSource = projectDeployData.GetMachinesByProjectIds(server, projects.Select(p => p.ProjectId).ToArray());
            }
            else
            {
                dgvMachine.DataSource = machines;
            }
        }

        /// <summary>
        /// 选择更改服务器触发
        /// </summary>
        /// <param name="sender">引发对象</param>
        /// <param name="e">事件参数</param>
        private void cbxServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProjectData(Convert.ToInt32(cbxServer.SelectedValue));
            cbxAllProject.Checked = false;
            cbxAllMachine.Checked = false;
            var server = cbxServer.SelectedItem as ServerInfo.Server;
            ProjectInfo.Project[] allProj;
            var projects = GetSelectDataGridData<ProjectInfo.Project>(dgvProject, (p, isSelect) =>
            {
                p.Selected = isSelect;
            }, out allProj);
            if (projects.IsNullOrLength0())
            {
                dgvMachine.DataSource = null;
                return;
            }
            dgvMachine.DataSource = projectDeployData.GetMachinesByProjectIds(server, projects.Select(p => p.ProjectId).ToArray());
        }

        /// <summary>
        /// 执行数据网格全部选择
        /// </summary>
        /// <param name="dgv">数据网格</param>
        /// <param name="isAllSelect">是否全部选择</param>
        private void ExecDataGridAllSelect(DataGridView dgv, bool isAllSelect)
        {
            foreach (var item in dgv.Rows)
            {
                var row = item as DataGridViewRow;
                var selectCell = row.Cells[0] as DataGridViewCheckBoxCell;
                selectCell.Value = isAllSelect;
            }
        }

        /// <summary>
        /// 点击全选项目触发
        /// </summary>
        /// <param name="sender">引发对象</param>
        /// <param name="e">事件参数</param>s
        private void cbxAllProject_CheckedChanged(object sender, EventArgs e)
        {
            ExecDataGridAllSelect(dgvProject, cbxAllProject.Checked);
            BindMachineData();
            //依据选择状态；更新字典状态
            for (int i = 0; i < dicProjectMapSelected.Count; i++)
            {
                dicProjectMapSelected[i]= cbxAllProject.Checked;
            }
            cbxAllMachine.Checked = cbxAllProject.Checked;
        }

        /// <summary>
        /// 获取选中的数据网格数据数组
        /// </summary>
        /// <returns>数据网格数据数组</returns>
        /// <param name="dgv">数据网格视图</param>
        /// <param name="action">循环每个数据回调</param>
        /// <param name="all">所有数据</param>
        private DataT[] GetSelectDataGridData<DataT>(DataGridView dgv, Action<DataT, bool> action, out DataT[] all) where DataT : class
        {
            all = null;
            if (dgv.Rows.Count == 0)
            {
                return null;
            }

            var list = new List<DataT>(dgv.Rows.Count);
            var listAll = new List<DataT>(dgv.Rows.Count);
            foreach (var item in dgv.Rows)
            {
                var row = item as DataGridViewRow;
                var selectCell = row.Cells[0] as DataGridViewCheckBoxCell;
                var isSelect = Convert.ToBoolean(selectCell.Value);
                var m = row.DataBoundItem as DataT;
                if (m == null)
                {
                    continue;
                }
                action(m, isSelect);
                listAll.Add(m);
                if (isSelect)
                {
                    list.Add(m);
                }
            }
            all = listAll.ToArray();

            return list.ToArray();
        }

        /// <summary>
        /// 点击发布触发
        /// </summary>
        /// <param name="sender">引发对象</param>
        /// <param name="e">事件参数</param>s
        private void btnPublish_Click(object sender, EventArgs e)
        {
            ExecPublish(true);
        }

        /// <summary>
        /// 点击项目单元格触发
        /// </summary>
        /// <param name="sender">引发对象</param>
        /// <param name="e">事件参数</param>s
        private void dgvProject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var row = dgvProject.Rows[e.RowIndex];
                var selectCell = row.Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                if (selectCell.EditingCellValueChanged)
                {
                    var machine = row.DataBoundItem as ProjectInfo.Project;
                    dicProjectMapSelected[machine.ProjectId] = !dicProjectMapSelected[machine.ProjectId];
                    selectCell.Value = dicProjectMapSelected[machine.ProjectId];
                    BindMachineData();
                }
            }
        }

        /// <summary>
        /// 点击全选物理机触发
        /// </summary>
        /// <param name="sender">引发对象</param>
        /// <param name="e">事件参数</param>s
        private void cbxAllMachine_CheckedChanged(object sender, EventArgs e)
        {
            ExecDataGridAllSelect(dgvProject, cbxAllMachine.Checked);
        }

        /// <summary>
        /// 点击测试连接触发
        /// </summary>
        /// <param name="sender">引发对象</param>
        /// <param name="e">事件参数</param>s
        private void btnTestConn_Click(object sender, EventArgs e)
        {
            ServerInfo.Machine[] selectMachines, allMachines;
            var remoteService = GetRemoteHandle(out selectMachines, out allMachines);
            if (remoteService == null)
            {
                return;
            }

            Task.Run(() =>
            {
                SetControllText(txtStatus, "远程连接中,请稍等...");
                var re = remoteService.TestConnectionAsync(selectMachines).Result;
                if (re.Failure())
                {
                    SetControllText(txtStatus, re.Msg);
                    return;
                }
                SetControllText(txtStatus, "处理完毕");
                BindMachineData(allMachines);
            });
        }

        /// <summary>
        /// 获取远程处理
        /// </summary>
        /// <param name="selectMachines">选择的物理机数组</param>
        /// <param name="allMachines">全部的物理机数组</param>
        /// <returns>远程服务</returns>
        private IRemoteService GetRemoteHandle(out ServerInfo.Machine[] selectMachines, out ServerInfo.Machine[] allMachines)
        {
            selectMachines = GetSelectDataGridData<ServerInfo.Machine>(dgvMachine, (p, isSelect) =>
            {
                p.Selected = isSelect;
            }, out allMachines);
            if (selectMachines.IsNullOrLength0())
            {
                MessageBox.Show($"请先选择物理机");
                return null;
            }

            var remoteService = GetRemoteService((byte)cbxRemoteWay.SelectedValue);
            if (remoteService == null)
            {
                var remoteWay = cbxRemoteWay.SelectedItem as RemoteWayInfo;
                MessageBox.Show($"不支持[{remoteWay.Name}]");
                return null;
            }

            return remoteService;
        }

        /// <summary>
        /// 根据远程方式获取远程服务
        /// </summary>
        /// <param name="remoteWay">远程方式</param>
        /// <returns>远程服务</returns>
        private IRemoteService GetRemoteService(byte remoteWay)
        {
            switch (remoteWay)
            {
                case 1:

                    return new FTPService();

                default:

                    return null;
            }
        }

        /// <summary>
        /// 追加文本控件文本
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="text">文本</param>
        private void SetControllText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action<Control, string>(SetControllText), control, text);
            }
            else
            {
                control.Text = text;
            }
        }

        /// <summary>
        /// 追加文本控件文本
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="text">文本</param>
        /// <param name="isAddLine">是否添加一行</param>
        private void AppendTextControllText(TextBox control, string text, bool isAddLine)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action<TextBox, string, bool>(AppendTextControllText), control, text, isAddLine);
            }
            else
            {
                if (isAddLine)
                {
                    text += Environment.NewLine;
                }
                control.AppendText(text);
            }
        }

        /// <summary>
        /// 点击本地发布触发
        /// </summary>
        /// <param name="sender">引发对象</param>
        /// <param name="e">事件参数</param>s
        private void btnLocalPublish_Click(object sender, EventArgs e)
        {
            ExecPublish(false);
        }

        /// <summary>
        /// 执行发布
        /// </summary>
        /// <param name="isRemotePublish">是否远程发布</param>
        private void ExecPublish(bool isRemotePublish)
        {
            txtStatus.Text = string.Empty;
            txtProgress.Text = string.Empty;
            ProjectInfo.Project[] allProj;
            var projects = GetSelectDataGridData<ProjectInfo.Project>(dgvProject, (p, isSelect) =>
            {
                p.Selected = isSelect;
            }, out allProj);
            if (projects.IsNullOrLength0())
            {
                MessageBox.Show($"请先选择项目");
                return;
            }
            ServerInfo.Machine[] selectMachines, allMachines;
            var remoteService = GetRemoteHandle(out selectMachines, out allMachines);
            if (remoteService == null)
            {
                return;
            }
            service.Set(remoteService);

            var enviVars = ddlEnviVar.SelectedIndex != -1 ? enviVarGroups[ddlEnviVar.SelectedItem.ToString()] : null;
            var server = cbxServer.SelectedItem as ServerInfo.Server;
            string err;
            var pds = projectDeployData.BuilderProjectPublishs(server, projects, selectMachines,
                enviVars, IsLocalCompile(), IsFullUpdate(), IsRemoteBak(), out err);
            if (!string.IsNullOrWhiteSpace(err))
            {
                MessageBox.Show(err);
                return;
            }
            if (pds.IsNullOrLength0())
            {
                MessageBox.Show("无项目部署可发布");
                return;
            }

            var publish = new PublishInfo()
            {
                ProjectGlobalConfig = projectData.GlobalConfig,
                ProjectPublishes = pds,
                IsRemotePublish = isRemotePublish,
                CallbackExecProject = (p, status, msg) =>
                {
                    AppendTextControllText(txtStatus, msg, true);
                },
                CallbackExecFileDesc = (p, status, msg, file, progress) =>
                {
                    AppendTextControllText(txtProgress, msg, true);
                }
            };

            var stop = new Stopwatch();
            stop.Start();
            Cursor.Current = Cursors.WaitCursor;
            Task.Run(() =>
            {
                AppendTextControllText(txtStatus, "发布中,请稍等...", true);
                var rePublish = service.PublishAsync(publish).Result;
                Cursor.Current = Cursors.Default;
                stop.Stop();
                var str = $"{stop.Elapsed.Hours}时{stop.Elapsed.Minutes}分{stop.Elapsed.Seconds}秒{stop.Elapsed.Milliseconds}毫秒";
                if (rePublish.Success())
                {
                    str = $"发布成功.耗时{str}";
                }
                else
                {
                    str = $"发布失败.{rePublish.Msg}.耗时{str}";
                }

                AppendTextControllText(txtStatus, str, true);
            });
        }

        /// <summary>
        /// 是否本地编译
        /// </summary>
        /// <returns>是否本地编译</returns>
        private bool? IsLocalCompile()
        {
            if (rbLocalCompileYes.Checked)
            {
                return true;
            }
            if (rbLocalCompileNo.Checked)
            {
                return false;
            }

            return null;
        }

        /// <summary>
        /// 是否全量更新
        /// </summary>
        /// <returns>是否全量更新</returns>
        private bool? IsFullUpdate()
        {
            if (rbFullUpdateYes.Checked)
            {
                return true;
            }
            if (rbFullUpdateNo.Checked)
            {
                return false;
            }

            return null;
        }

        /// <summary>
        /// 是否远程备份
        /// </summary>
        /// <returns>是否远程备份</returns>
        private bool? IsRemoteBak()
        {
            if (rbRemoteBakYes.Checked)
            {
                return true;
            }
            if (rbRemoteBakNo.Checked)
            {
                return false;
            }

            return null;
        }
    }
}
