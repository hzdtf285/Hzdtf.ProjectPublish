using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hzdtf.PublishProject.Model.Publish;
using Hzdtf.Utility.Utils;

namespace Hzdtf.PublishProject.Model.Project
{
    /// <summary>
    /// 项目信息
    /// @ 黄振东
    /// </summary>
    public class ProjectInfo
    {
        /// <summary>
        /// 项目数组
        /// </summary>
        public Project[] Projects { get; set; }

        /// <summary>
        /// 全局配置
        /// </summary>
        public GlobalConfigInfo GlobalConfig
        {
            get;
            set;
        }

        /// <summary>
        /// 项目
        /// @ 黄振东
        /// </summary>
        public class Project : ICloneable
        {
            /// <summary>
            /// 项目ID
            /// </summary>
            public int ProjectId { get; set; }

            /// <summary>
            /// 项目名称
            /// </summary>
            public string ProjectName { get; set; }

            /// <summary>
            /// 源代码
            /// </summary>
            public Sourcecode SourceCode { get; set; }

            /// <summary>
            /// 是否选中
            /// </summary>
            public bool Selected
            {
                get;
                set;
            }

            /// <summary>
            /// 需要发布的文件数组
            /// </summary>
            public PublishFileInfo[] PublishFiles
            {
                get;
                set;
            }

            /// <summary>
            /// 版本文件，默认是files.ver
            /// </summary>
            public string VersionFile
            {
                get;
                set;
            } = "files.ver";

            /// <summary>
            /// 浅拷贝
            /// </summary>
            /// <returns>项目信息</returns>
            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        /// <summary>
        /// 全局配置信息
        /// @ 黄振东
        /// </summary>
        public class GlobalConfigInfo
        {
            /// <summary>
            /// 忽略文件数组
            /// </summary>
            public string[] IgnoreFiles { get; set; }
        }

        /// <summary>
        /// 源代码
        /// @ 黄振东
        /// </summary>
        public class Sourcecode
        {
            /// <summary>
            /// 原始发布进程文件名
            /// </summary>
            private string protoPublishProcessFileName;

            /// <summary>
            /// 发布进程文件名
            /// </summary>
            public string PublishProcessFileName { get; set; }

            /// <summary>
            /// 原始发布进程参数
            /// </summary>
            private string protoPublishProcessArguments;

            /// <summary>
            /// 发布进程参数
            /// </summary>
            public string PublishProcessArguments { get; set; }

            /// <summary>
            /// 发布之前是否删除目标
            /// </summary>
            public bool BeforePublishRemove { get; set; }

            /// <summary>
            /// 是否本地编译，默认为是
            /// </summary>
            public bool IsLocalCompile
            {
                get;
                set;
            } = true;
                
            /// <summary>
            /// 是否全量更新
            /// </summary>
            public bool IsFullUpdate { get; set; }

            /// <summary>
            /// 发布到目标路径
            /// </summary>
            public string PublishOutPath { get; set; }

            /// <summary>
            /// 忽略文件数组
            /// </summary>
            public string[] IgnoreFiles { get; set; }

            /// <summary>
            /// 部署前是否需要备份
            /// </summary>
            public bool BeforeDeployBak
            {
                get;
                set;
            }

            /// <summary>
            /// 是否初始替换环境变量
            /// </summary>
            private bool isFristReplEnvi = true;

            /// <summary>
            /// 环境替换环境变量
            /// </summary>
            /// <param name="enviVars">环境变量</param>
            public void ExecReplaceEnviVars(IDictionary<string, string> enviVars)
            {
                if (enviVars.IsNullOrCount0())
                {
                    return;
                }

                if (isFristReplEnvi)
                {
                    protoPublishProcessFileName = PublishProcessFileName;
                    protoPublishProcessArguments = PublishProcessArguments;

                    isFristReplEnvi = false;
                }
                else
                {
                    PublishProcessFileName = protoPublishProcessFileName;
                    PublishProcessArguments = protoPublishProcessArguments;
                }

                foreach (var ev in enviVars)
                {
                    var name = $"$[{ev.Key}]";
                    if (!string.IsNullOrWhiteSpace(PublishProcessFileName))
                    {
                        PublishProcessFileName = PublishProcessFileName.Replace(name, ev.Value);
                    }
                    if (!string.IsNullOrWhiteSpace(PublishProcessArguments))
                    {
                        PublishProcessArguments = PublishProcessArguments.Replace(name, ev.Value);
                    }
                    if (!string.IsNullOrWhiteSpace(PublishOutPath))
                    {
                        PublishOutPath = PublishOutPath.Replace(name, ev.Value);
                    }
                }
            }
        }
    }
}
