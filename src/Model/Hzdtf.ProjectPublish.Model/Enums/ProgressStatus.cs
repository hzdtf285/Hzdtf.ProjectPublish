using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.ProjectPublish.Model.Emums
{
    /// <summary>
    /// 进程状态枚举
    /// @ 黄振东
    /// </summary>
    public enum ProgressStatus : byte
    {
        /// <summary>
        /// 执行前
        /// </summary>
        BeforeExec = 0,

        /// <summary>
        /// 执行中
        /// </summary>
        Execing = 1,

        /// <summary>
        /// 执行后
        /// </summary>
        AfterExec = 2
    }
}
