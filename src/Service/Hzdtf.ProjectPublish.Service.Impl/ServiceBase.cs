using Hzdtf.Logger.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.ProjectPublish.Service.Impl
{
    /// <summary>
    /// 服务基类
    /// @ 黄振东
    /// </summary>
    public abstract class ServiceBase
    {
        /// <summary>
        /// 日志
        /// </summary>
        protected readonly ILogable log;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="log">日志</param>
        public ServiceBase(ILogable log = null)
        {
            if (log == null)
            {
                log = LogTool.DefaultLog;
            }
            this.log = log;
        }
    }
}
