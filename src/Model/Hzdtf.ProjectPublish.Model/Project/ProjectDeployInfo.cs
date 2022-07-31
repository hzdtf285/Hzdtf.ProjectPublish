using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.PublishProject.Model.Project
{
    /// <summary>
    /// 项目部署信息
    /// @ 黄振东
    /// </summary>
    public class ProjectDeployInfo
    {
        /// <summary>
        /// 项目部署数组
        /// </summary>
        public Projectdeploy[] ProjectDeploys { get; set; }

        /// <summary>
        /// 项目部署
        /// @ 黄振东
        /// </summary>
        public class Projectdeploy : ICloneable
        {
            /// <summary>
            /// 项目部署ID
            /// </summary>
            public int ProjectDeployId { get; set; }

            /// <summary>
            /// 项目ID
            /// </summary>
            public int ProjectId { get; set; }

            /// <summary>
            /// 服务器ID
            /// </summary>
            public int ServerId { get; set; }

            /// <summary>
            /// 物理机ID
            /// </summary>
            public int MachineId { get; set; }

            /// <summary>
            /// 项目部署路径
            /// </summary>
            public string ProjectDeployPath { get; set; }

            /// <summary>
            /// 环境变量组
            /// </summary>
            public string EnviVarGroup { get; set; }

            /// <summary>
            /// 浅拷贝
            /// </summary>
            /// <returns>项目部署</returns>
            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }
    }
}
