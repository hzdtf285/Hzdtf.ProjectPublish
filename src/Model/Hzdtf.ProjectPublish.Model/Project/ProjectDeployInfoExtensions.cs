using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hzdtf.PublishProject.Model.Server;
using Hzdtf.Utility.AutoMapperExtensions;
using Hzdtf.Utility.Utils;

namespace Hzdtf.PublishProject.Model.Project
{
    /// <summary>
    /// 项目部署信息扩展类
    /// @ 黄振东
    /// </summary>
    public static class ProjectDeployInfoExtensions
    {
        /// <summary>
        /// 根据服务器ID获取项目数组
        /// </summary>
        /// <param name="projectDeploy">项目部署</param>
        /// <param name="project">项目</param>
        /// <param name="serverId">服务器ID</param>
        /// <returns>项目数组</returns>
        public static ProjectInfo.Project[] GetProjectsByServerId(this ProjectDeployInfo projectDeploy, ProjectInfo project, int serverId)
        {
            if (projectDeploy == null || projectDeploy.ProjectDeploys.IsNullOrLength0() 
                || project == null || project.Projects.IsNullOrLength0())
            {
                return null;
            }

            var projectIds = projectDeploy.ProjectDeploys.Where(p => p.ServerId == serverId).Select(p => p.ProjectId).ToArray();
            return project.Projects.Where(p => projectIds.Contains(p.ProjectId)).ToArray();
        }

        /// <summary>
        /// 根据项目ID数组获取物理机数组
        /// </summary>
        /// <param name="projectDeploy">项目部署</param>
        /// <param name="server">服务器</param>
        /// <param name="projectIds">项目ID数组</param>
        /// <returns>物理机数组></returns>
        public static ServerInfo.Machine[] GetMachinesByProjectIds(this ProjectDeployInfo projectDeploy, ServerInfo.Server server, int[] projectIds)
        {
            if (projectDeploy == null || projectDeploy.ProjectDeploys.IsNullOrLength0()
                || server == null || projectIds.IsNullOrLength0())
            {
                return null;
            }

            var proDeploys = projectDeploy.ProjectDeploys.Where(p => p.ServerId == server.ServerId && projectIds.Contains(p.ProjectId)).ToArray();
            if (proDeploys.IsNullOrLength0())
            {
                return null;
            }

            var mechines = new List<ServerInfo.Machine>(proDeploys.Length);
            foreach (var pd in proDeploys)
            {
                var ms = server.Machines.Where(p => p.MachineId == pd.MachineId).ToArray();
                if (ms.IsNullOrLength0())
                {
                    continue;
                }

                foreach (var m in ms)
                {
                    if (mechines.Where(a => a.MachineId == m.MachineId).Count() > 0)
                    {
                        continue;
                    }

                    mechines.Add(m);
                }
            }

            return mechines.ToArray();
        }

        /// <summary>
        /// 生成项目发布数组
        /// </summary>
        /// <param name="projectDeploy">项目部署</param>
        /// <param name="server">服务器</param>
        /// <param name="selectProjects">选中的项目数组</param>
        /// <param name="selectMachines">选中的物理机数组</param>
        /// <param name="defaultEnviVars">默认的环境变量</param>
        /// <param name="isLocalCompile">是否本地编译</param>
        /// <param name="isFullUpdate">是否全量更新</param>
        /// <param name="isRemoteBak">是否远程备份</param>
        /// <param name="err">错误消息</param>
        /// <returns>项目发布数组</returns>
        public static ProjectPublishInfo[] BuilderProjectPublishs(this ProjectDeployInfo projectDeploy, ServerInfo.Server server, ProjectInfo.Project[] selectProjects, ServerInfo.Machine[] selectMachines,
            IDictionary<string, string> defaultEnviVars, bool? isLocalCompile, bool? isFullUpdate, bool? isRemoteBak, out string err)
        {
            err = null;
            if (projectDeploy == null || projectDeploy.ProjectDeploys.IsNullOrLength0()
                || server == null || selectMachines.IsNullOrLength0() || selectProjects.IsNullOrLength0())
            {
                return null;
            }

            var result = AutoMapperUtil.Mapper.Map<ProjectInfo.Project[], ProjectPublishInfo[]>(selectProjects);
            var machineIds = selectMachines.Select(p => p.MachineId).ToArray();

            // 循环项目发布数组
            foreach (var item in result)
            {
                // 查找该项目上的选择的物理机
                var pds = projectDeploy.ProjectDeploys.Where(p => p.ProjectId == item.ProjectId && p.ServerId == server.ServerId && machineIds.Contains(p.MachineId)).ToArray();
                if (pds.IsNullOrLength0())
                {
                    err = $"找不到项目ID[{item.ProjectId}]的物理机部署";

                    return null;
                }
                item.ServerId = server.ServerId;
                item.ServerName = server.ServerName;
                if (isLocalCompile != null)
                {
                    item.SourceCode.IsLocalCompile = (bool)isLocalCompile;
                }
                if (isFullUpdate != null)
                {
                    item.SourceCode.IsFullUpdate = (bool)isFullUpdate;
                }
                if (isRemoteBak != null)
                {
                    item.SourceCode.BeforeDeployBak = (bool)isRemoteBak;
                }
                item.SourceCode.ExecReplaceEnviVars(defaultEnviVars);

                item.ProjectMachines = new ProjectMachineInfo[pds.Length];
                for (var i = 0; i < pds.Length; i++)
                {
                    // 根据项目ID和物理机ID查找
                    var machine = selectMachines.Where(p => p.MachineId == pds[i].MachineId).FirstOrDefault();
                    if (machine == null)
                    {
                        err = $"找不到物理机ID[{pds[i].MachineId}]的物理机";

                        return null;
                    }
                    var tempPd = pds.Where(p => p.ProjectId == item.ProjectId && p.MachineId == pds[i].MachineId).FirstOrDefault();
                    if (tempPd == null)
                    {
                        err = $"找不到项目ID[{item.ProjectId}]和物理机ID[{pds[i].MachineId}]的项目部署";

                        return null;
                    }

                    item.ProjectMachines[i] = new ProjectMachineInfo()
                    {
                        Machine = machine,
                        Projectdeploy = tempPd
                    };
                }
            }

            return result;
        }
    }
}
