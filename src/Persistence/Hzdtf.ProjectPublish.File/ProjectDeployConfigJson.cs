using Hzdtf.PublishProject.Model.Project;
using Hzdtf.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.ProjectPublish.File
{
    /// <summary>
    /// 项目部署配置Json
    /// @ 黄振东
    /// </summary>
    public class ProjectDeployConfigJson : IReader<ProjectDeployInfo>
    {
        /// <summary>
        /// JSON文件
        /// </summary>
        private readonly string jsonFile;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="jsonFile">JSON文件，默认为/Config/projectDeploy.json</param>
        public ProjectDeployConfigJson(string jsonFile = null)
        {
            if (jsonFile == null)
            {
                jsonFile = $"{AppContext.BaseDirectory}/Config/projectDeploy.json";
            }
            this.jsonFile = jsonFile;
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <returns>项目部署信息</returns>
        public ProjectDeployInfo Reader()
        {
            return jsonFile.ToJsonObjectFromFile<ProjectDeployInfo>();
        }
    }
}
