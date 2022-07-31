using Hzdtf.PublishProject.Model.Project;
using Hzdtf.PublishProject.Model.Server;
using Hzdtf.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.ProjectPublish.Persistence.Contract
{
    /// <summary>
    /// 配置工厂接口
    /// @ 黄振东
    /// </summary>
    public interface IConfigFactory
    {
        /// <summary>
        /// 创建项目读取
        /// </summary>
        /// <returns>项目读取</returns>
        IReader<ProjectInfo> CreateProjectReader();

        /// <summary>
        /// 创建服务器读取
        /// </summary>
        /// <returns>服务器读取</returns>
        IReader<ServerInfo> CreateServerReader();

        /// <summary>
        /// 创建项目部署读取
        /// </summary>
        /// <returns>项目部署读取</returns>
        IReader<ProjectDeployInfo> CreateProjectDeployReader();

        /// <summary>
        /// 创建环境变量组读取
        /// </summary>
        /// <returns>环境变量组读取</returns>
        IReader<IDictionary<string, IDictionary<string, string>>> CreateEnviVarGroupReader();
    }
}
