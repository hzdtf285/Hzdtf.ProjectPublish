using Hzdtf.ProjectPublish.Model.Emums;
using Hzdtf.ProjectPublish.Model.Publish;
using Hzdtf.ProjectPublish.Remote.Contract;
using Hzdtf.ProjectPublish.Service.Contract;
using Hzdtf.PublishProject.Model.Publish;
using Hzdtf.Utility.Model.Return;
using Hzdtf.Utility.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.ProjectPublish.Service.Impl
{
    /// <summary>
    /// 发布服务
    /// @ 黄振东
    /// </summary>
    public class PublishService : ServiceBase, IPublishService
    {
        /// <summary>
        /// 远程服务
        /// </summary>
        private IRemoteService remoteService;

        /// <summary>
        /// 当前操作ID
        /// </summary>
        private string currHandleId = null;

        /// <summary>
        /// 设置远程服务
        /// </summary>
        /// <param name="remoteService">远程服务</param>
        public void Set(IRemoteService remoteService)
        {
            this.remoteService = remoteService;
        }

        /// <summary>
        /// 异步发布
        /// </summary>
        /// <param name="publish">发布信息</param>
        /// <returns>任务</returns>
        public async Task<BasicReturnInfo> PublishAsync(PublishInfo publish)
        {
            currHandleId = NumberUtil.Random(8);
            var rePublish = ExecLocalProjectsPublish(publish);
            if (publish.IsRemotePublish)
            {
                rePublish = await remoteService.PublishAsync(publish, currHandleId);
            }
            currHandleId = null;

            return rePublish;
        }

        /// <summary>
        /// 执行本地项目发布
        /// </summary>
        /// <param name="publish">发布信息</param>
        /// <returns>返回信息</returns>
        private BasicReturnInfo ExecLocalProjectsPublish(PublishInfo publish)
        {
            var re = new BasicReturnInfo();
            try
            {
                foreach (var projectPublish in publish.ProjectPublishes)
                {
                    var sourceCode = projectPublish.SourceCode;
                    // 如果发布可执行文件为空，则自动找发布后的文件夹所有文件
                    if (string.IsNullOrWhiteSpace(sourceCode.PublishProcessFileName) && string.IsNullOrWhiteSpace(sourceCode.PublishOutPath))
                    {
                        re.SetFailureMsg($"[{projectPublish.ProjectName}]发布到目标路径为空");
                        return re;
                    }

                    if (sourceCode.IsLocalCompile && !string.IsNullOrWhiteSpace(sourceCode.PublishProcessFileName))
                    {
                        // 如果要先删除发布的路径
                        if (sourceCode.BeforePublishRemove)
                        {
                            sourceCode.PublishOutPath.DeleteDirectory();
                        }

                        string err = null;
                        var publishResult = sourceCode.PublishProcessFileName.ExecCommand(sourceCode.PublishProcessArguments, out err);
                        if (string.IsNullOrWhiteSpace(err))
                        {
                            var msg = $"项目[{projectPublish.ProjectName}]本地发布返回:{publishResult}";
                            log.WranAsync(msg, null, typeof(PublishService).Name, currHandleId, "ExecLocalProjectPublish");
                            publish.CallbackExecProject(projectPublish, ProgressStatus.Execing, msg);
                        }
                        else
                        {
                            var msg = $"项目[{projectPublish.ProjectName}]本地发布返回:{publishResult}";
                            log.InfoAsync(msg, null, typeof(PublishService).Name, currHandleId, "ExecLocalProjectPublish");
                            publish.CallbackExecProject(projectPublish, ProgressStatus.AfterExec, msg);
                            return re;
                        }
                    }

                    var files = Directory.GetFiles(sourceCode.PublishOutPath, "*", searchOption: SearchOption.AllDirectories);
                    if (files.IsNullOrLength0())
                    {
                        var msg = $"项目[{projectPublish.ProjectName}]发布后的本地文件为空";
                        log.InfoAsync(msg, null, typeof(PublishService).Name, currHandleId, "ExecLocalProjectPublish");
                        publish.CallbackExecProject(projectPublish, ProgressStatus.Execing, msg);
                        continue;
                    }

                    var fileList = new List<PublishFileInfo>(files.Length);
                    var startLength = sourceCode.PublishOutPath.Length;
                    foreach (var f in files)
                    {
                        var newFile = f.Substring(startLength);
                        if (newFile.StartsWith("\\"))
                        {
                            newFile = newFile.Substring(1);
                        }
                        else if (newFile.StartsWith("/"))
                        {
                            newFile = newFile.Substring(1);
                        }

                        // 排除版本文件
                        if (newFile.Equals(projectPublish.VersionFile))
                        {
                            continue;
                        }

                        // 全局配置文件忽略
                        if (publish.ProjectGlobalConfig != null && !publish.ProjectGlobalConfig.IgnoreFiles.IsNullOrLength0())
                        {
                            bool isIgnore = false;
                            foreach (var itemF in publish.ProjectGlobalConfig.IgnoreFiles)
                            {
                                var lastChar = itemF.Substring(itemF.Length - 1);
                                if ("*".Equals(lastChar))
                                {
                                    var newItemF = itemF.Substring(0, itemF.Length - 1);
                                    if (newFile.StartsWith(newItemF))
                                    {
                                        isIgnore = true;
                                        break;
                                    }
                                }
                                else if (itemF.Equals(newFile))
                                {
                                    isIgnore = true;
                                    break;
                                }
                            }
                            if (isIgnore)
                            {
                                continue;
                            }
                        }
                        // 项目配置文件忽略
                        if (!sourceCode.IgnoreFiles.IsNullOrLength0() && sourceCode.IgnoreFiles.Contains(newFile))
                        {
                            bool isIgnore = false;
                            foreach (var itemF in sourceCode.IgnoreFiles)
                            {
                                var lastChar = itemF.Substring(itemF.Length - 1);
                                if ("*".Equals(lastChar))
                                {
                                    var newItemF = itemF.Substring(0, itemF.Length - 1);
                                    if (newFile.StartsWith(newItemF))
                                    {
                                        isIgnore = true;
                                        break;
                                    }
                                }
                                else if (itemF.Equals(newFile))
                                {
                                    isIgnore = true;
                                    break;
                                }
                            }
                            if (isIgnore)
                            {
                                continue;
                            }
                        }

                        fileList.Add(new PublishFileInfo()
                        {
                            FileName = newFile,
                            FileFullName = f
                        });
                    }

                    projectPublish.PublishFiles = fileList.ToArray();

                }
            }
            catch (Exception ex)
            {
                log.ErrorAsync(ex.Message, ex, typeof(PublishService).Name, "ExecLocalProjectPublish", currHandleId);
                re.SetFailureMsg(ex.Message, ex.StackTrace);
            }

            return re;
        }
    }
}
