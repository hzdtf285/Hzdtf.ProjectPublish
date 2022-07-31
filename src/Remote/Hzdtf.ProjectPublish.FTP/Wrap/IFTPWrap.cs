using FluentFTP;
using Hzdtf.PublishProject.Model.Server;
using Hzdtf.Utility.Release;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.ProjectPublish.FTP.Wrap
{
    /// <summary>
    /// FTP包装接口
    /// @ 黄振东
    /// </summary>
    public interface IFTPWrap : IClose, IDisposable
    {
        /// <summary>
        /// 异步获取一个可用的FTP客户端
        /// </summary>
        /// <param name="machine">物理机</param>
        /// <returns>任务</returns>
        Task<FtpClient> GetCanUseFtpAsync(ServerInfo.Machine machine);
    }
}
