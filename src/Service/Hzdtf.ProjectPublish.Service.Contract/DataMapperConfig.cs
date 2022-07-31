using AutoMapper;
using Hzdtf.PublishProject.Model.Project;
using Hzdtf.Utility.AutoMapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.ProjectPublish.Service.Contract
{
    /// <summary>
    /// 数据映射配置
    /// @ 黄振东
    /// </summary>
    public class DataMapperConfig : IAutoMapperConfig
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="config">配置</param>
        public void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<ProjectInfo.Project, ProjectPublishInfo>();
        }
    }
}
