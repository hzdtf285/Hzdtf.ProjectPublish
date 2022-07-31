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
    /// 项目配置Json
    /// @ 黄振东
    /// </summary>
    public class ProjectConfigJson : IReader<ProjectInfo>
    {
        /// <summary>
        /// JSON文件
        /// </summary>
        private readonly string jsonFile;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="jsonFile">JSON文件，默认为/Config/project.json</param>
        public ProjectConfigJson(string jsonFile = null)
        {
            if (jsonFile == null)
            {
                jsonFile = $"{AppContext.BaseDirectory}/Config/project.json";
            }
            this.jsonFile = jsonFile;
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <returns>项目信息</returns>
        public ProjectInfo Reader()
        {
            return jsonFile.ToJsonObjectFromFile<ProjectInfo>();
        }
    }
}
