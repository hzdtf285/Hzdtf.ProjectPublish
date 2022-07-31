using Hzdtf.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.ProjectPublish.File
{
    /// <summary>
    /// 环境变量组配置Json
    /// @ 黄振东
    /// </summary>
    public class EnviVarGroupConfigJson : IReader<IDictionary<string, IDictionary<string, string>>>
    {
        /// <summary>
        /// JSON文件
        /// </summary>
        private readonly string jsonFile;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="jsonFile">JSON文件，默认为/Config/enviVarGroup.json</param>
        public EnviVarGroupConfigJson(string jsonFile = null)
        {
            if (jsonFile == null)
            {
                jsonFile = $"{AppContext.BaseDirectory}/Config/enviVarGroup.json";
            }
            this.jsonFile = jsonFile;
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <returns>环境变量组字典</returns>
        public IDictionary<string, IDictionary<string, string>> Reader()
        {
            return jsonFile.ToJsonObjectFromFile<IDictionary<string, IDictionary<string, string>>>();
        }
    }
}
