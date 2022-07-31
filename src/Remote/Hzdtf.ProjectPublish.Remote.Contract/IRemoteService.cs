using Hzdtf.ProjectPublish.Model.Publish;
using Hzdtf.PublishProject.Model.Server;
using Hzdtf.Utility.Model.Return;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.ProjectPublish.Remote.Contract
{
    /// <summary>
    /// 远程服务接口
    /// @ 黄振东
    /// </summary>
    public interface IRemoteService
    {
        /// <summary>
        /// 异步测试连接
        /// </summary>
        /// <param name="machines">物理机数组</param>
        /// <returns>任务</returns>
        Task<BasicReturnInfo> TestConnectionAsync(params ServerInfo.Machine[] machines);

        /// <summary>
        /// 异步发布
        /// </summary>
        /// <param name="publish">发布信息</param>
        /// <param name="handleId">操作ID</param>
        /// <returns>任务</returns>
        Task<BasicReturnInfo> PublishAsync(PublishInfo publish, string handleId = null);
    }
}
