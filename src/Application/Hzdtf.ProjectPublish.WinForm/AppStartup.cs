using Hzdtf.Logger.Contract;
using Hzdtf.Logger.Integration.ENLog;
using Hzdtf.Utility.AutoMapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.ProjectPublish.WinForm
{
    /// <summary>
    /// 应用启动
    /// @ 黄振东
    /// </summary>
    public static class AppStartup
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            AutoMapperUtil.AutoRegisterConfig(new string[] { "Hzdtf.ProjectPublish.Service.Contract" });
            AutoMapperUtil.Builder();

            LogTool.DefaultLog = new IntegrationNLog();
        }
    }
}
