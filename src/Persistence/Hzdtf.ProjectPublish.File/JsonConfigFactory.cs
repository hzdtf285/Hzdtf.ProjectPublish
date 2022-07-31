using Hzdtf.ProjectPublish.Persistence.Contract;
using Hzdtf.PublishProject.Model.Project;
using Hzdtf.PublishProject.Model.Server;
using Hzdtf.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.ProjectPublish.File
{
    /// <summary>
    /// Json配置工厂
    /// @ 黄振东
    /// </summary>
    public class JsonConfigFactory : IConfigFactory
    {
        /// <summary>
        /// 项目JSON文件
        /// </summary>
        private readonly string projectJsonFile;

        /// <summary>
        /// 服务器JSON文件
        /// </summary>
        private readonly string serverJsonFile;

        /// <summary>
        /// 项目部署JSON文件
        /// </summary>
        private readonly string projectDeployJsonFile;

        /// <summary>
        /// 环境变量组JSON文件
        /// </summary>
        private readonly string enviVarGroupJsonFile;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="projectJsonFile">项目JSON文件</param>
        /// <param name="serverJsonFile">服务器JSON文件</param>
        /// <param name="projectDeployJsonFile">项目部署JSON文件</param>
        /// <param name="enviVarGroupJsonFile">环境变量组JSON文件</param>
        public JsonConfigFactory(string projectJsonFile = null, string serverJsonFile = null, string projectDeployJsonFile = null, string enviVarGroupJsonFile = null)
        {
            this.projectJsonFile = projectJsonFile;
            this.serverJsonFile = serverJsonFile;
            this.projectDeployJsonFile = projectDeployJsonFile;
            this.enviVarGroupJsonFile = enviVarGroupJsonFile;
        }

        /// <summary>
        /// 创建项目读取
        /// </summary>
        /// <returns>项目读取</returns>
        public IReader<ProjectInfo> CreateProjectReader() => new ProjectConfigJson(projectJsonFile);

        /// <summary>
        /// 创建服务器读取
        /// </summary>
        /// <returns>服务器读取</returns>
        public IReader<ServerInfo> CreateServerReader() => new ServerConfigJson(serverJsonFile);

        /// <summary>
        /// 创建项目部署读取
        /// </summary>
        /// <returns>项目部署读取</returns>
        public IReader<ProjectDeployInfo> CreateProjectDeployReader() => new ProjectDeployConfigJson(projectDeployJsonFile);

        /// <summary>
        /// 创建环境变量组读取
        /// </summary>
        /// <returns>环境变量组读取</returns>
        public IReader<IDictionary<string, IDictionary<string, string>>> CreateEnviVarGroupReader() => new EnviVarGroupConfigJson(enviVarGroupJsonFile);
    }
}
