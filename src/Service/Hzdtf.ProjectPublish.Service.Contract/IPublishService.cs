using Hzdtf.ProjectPublish.Model.Publish;
using Hzdtf.ProjectPublish.Remote.Contract;
using Hzdtf.Utility.Data;
using Hzdtf.Utility.Model.Return;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.ProjectPublish.Service.Contract
{
    /// <summary>
    /// 发布服务接口
    /// @ 黄振东
    /// </summary>
    public interface IPublishService : ISetObject<IRemoteService>
    {
        /// <summary>
        /// 异步发布
        /// </summary>
        /// <param name="publish">发布信息</param>
        /// <returns>任务</returns>
        Task<BasicReturnInfo> PublishAsync(PublishInfo publish);
    }
}
