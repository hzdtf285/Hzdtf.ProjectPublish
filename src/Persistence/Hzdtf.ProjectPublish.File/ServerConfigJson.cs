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
    /// 服务器配置Json
    /// @ 黄振东
    /// </summary>
    public class ServerConfigJson : IReader<ServerInfo>
    {
        /// <summary>
        /// JSON文件
        /// </summary>
        private readonly string jsonFile;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="jsonFile">JSON文件，默认为/Config/server.json</param>
        public ServerConfigJson(string jsonFile = null)
        {
            if (jsonFile == null)
            {
                jsonFile = $"{AppContext.BaseDirectory}/Config/server.json";
            }
            this.jsonFile = jsonFile;
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <returns>服务器信息</returns>
        public ServerInfo Reader()
        {
            return jsonFile.ToJsonObjectFromFile<ServerInfo>();
        }
    }
}
