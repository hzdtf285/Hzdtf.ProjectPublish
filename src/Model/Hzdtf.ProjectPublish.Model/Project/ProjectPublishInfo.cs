using Hzdtf.PublishProject.Model.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.PublishProject.Model.Project
{
    /// <summary>
    /// 项目发布信息
    /// @ 黄振东
    /// </summary>
    public class ProjectPublishInfo : ProjectInfo.Project
    {
        /// <summary>
        /// 项目物理机数组
        /// </summary>
        public ProjectMachineInfo[] ProjectMachines
        {
            get;
            set;
        }

        /// <summary>
        /// 服务器ID
        /// </summary>
        public int ServerId
        {
            get;
            set;
        }

        /// <summary>
        /// 服务器名称
        /// </summary>
        public string ServerName
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 项目物理机信息
    /// @ 黄振东
    /// </summary>
    public class ProjectMachineInfo
    {
        /// <summary>
        /// 物理机
        /// </summary>
        public ServerInfo.Machine Machine
        {
            get;
            set;
        }

        /// <summary>
        /// 项目部署
        /// </summary>
        public ProjectDeployInfo.Projectdeploy Projectdeploy
        {
            get;
            set;
        }
    }
}
