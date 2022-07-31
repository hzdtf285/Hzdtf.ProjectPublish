using Hzdtf.ProjectPublish.Model.Emums;
using Hzdtf.PublishProject.Model.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.ProjectPublish.Model.Publish
{
    /// <summary>
    /// 发布信息
    /// </summary>
    public class PublishInfo
    {
        /// <summary>
        /// 项目发布数组
        /// </summary>
        public ProjectPublishInfo[] ProjectPublishes
        {
            get;
            set;
        }

        /// <summary>
        /// 项目全局配置
        /// </summary>
        public ProjectInfo.GlobalConfigInfo ProjectGlobalConfig
        {
            get;
            set;
        }

        /// <summary>
        /// 是否远程发布
        /// </summary>
        public bool IsRemotePublish
        {
            get;
            set;
        }

        /// <summary>
        /// 回调执行项目
        /// </summary>
        public Action<ProjectPublishInfo, ProgressStatus, string> CallbackExecProject
        {
            get;
            set;
        }

        /// <summary>
        /// 回调执行项目文件明细
        /// </summary>
        public Action<ProjectPublishInfo, ProgressStatus, string, string, double> CallbackExecFileDesc
        {
            get;
            set;
        }

        /// <summary>
        /// 调用回调执行项目
        /// </summary>
        /// <param name="projectPublish">项目发布</param>
        /// <param name="status">进度状态</param>
        /// <param name="msg">消息</param>
        public void OnCallbackExecProject(ProjectPublishInfo projectPublish, ProgressStatus status, string msg)
        {
            if (CallbackExecProject == null)
            {
                return;
            }

            CallbackExecProject(projectPublish, status, msg);
        }

        /// <summary>
        /// 调用回调执行项目文件明细
        /// </summary>
        /// <param name="projectPublish">项目发布</param>
        /// <param name="status">进度状态</param>
        /// <param name="msg">消息</param>
        /// <param name="fileName">文件名</param>
        /// <param name="progress">进程数字</param>
        public void OnCallbackExecFileDesc(ProjectPublishInfo projectPublish, ProgressStatus status, string msg, string fileName, double progress)
        {
            if (CallbackExecFileDesc == null)
            {
                return;
            }

            CallbackExecFileDesc(projectPublish, status, msg, fileName, progress);
        }
    }
}
