using FluentFTP;
using Hzdtf.ProjectPublish.FTP.Wrap;
using Hzdtf.PublishProject.Model.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hzdtf.Utility.Model.Return;
using Hzdtf.ProjectPublish.Remote.Contract;
using Hzdtf.ProjectPublish.Model.Publish;
using Hzdtf.PublishProject.Model.Project;
using Hzdtf.Logger.Contract;
using Hzdtf.Utility.Utils;
using Hzdtf.Utility.Safety;
using Hzdtf.ProjectPublish.Model.Emums;
using System.IO;

namespace Hzdtf.ProjectPublish.FTP
{
    /// <summary>
    /// FTP服务
    /// @ 黄振东
    /// </summary>
    public class FTPService : IRemoteService
    {
        /// <summary>
        /// FTP包装
        /// </summary>
        private readonly IFTPWrap ftpWrap;

        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILogable log;

        /// <summary>
        /// 操作ID
        /// </summary>
        private string handleId;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="ftpWrap">FTP包装</param>
        /// <param name="log">日志</param>
        public FTPService(IFTPWrap ftpWrap = null, ILogable log = null)
        {
            if (ftpWrap == null)
            {
                ftpWrap = new FTPWrap();
            }
            if (log == null)
            {
                log = LogTool.DefaultLog;
            }
            this.ftpWrap = ftpWrap;
            this.log = log;
        }

        /// <summary>
        /// 异步测试连接
        /// </summary>
        /// <param name="machines">物理机数组</param>
        /// <returns>任务</returns>
        public async Task<BasicReturnInfo> TestConnectionAsync(params ServerInfo.Machine[] machines)
        {
            return await Task<BasicReturnInfo>.Run(() =>
            {
                var re = new BasicReturnInfo();
                Task<FtpClient>[] taskClients = new Task<FtpClient>[machines.Length];
                try
                {
                    for (var i = 0; i < machines.Length; i++)
                    {
                        taskClients[i] = ftpWrap.GetCanUseFtpAsync(machines[i]);
                    }

                    Task.WaitAll(taskClients);
                }
                catch (Exception ex)
                {
                    re.SetFailureMsg(ex.Message, ex.StackTrace);
                }
                finally
                {
                    ftpWrap.Close();
                    ftpWrap.Dispose();
                }

                return re;
            });
        }

        /// <summary>
        /// 异步发布
        /// </summary>
        /// <param name="publish">发布信息</param>
        /// <param name="handleId">操作ID</param>
        /// <returns>任务</returns>
        public async Task<BasicReturnInfo> PublishAsync(PublishInfo publish, string handleId = null)
        {
            this.handleId = handleId;
            var re = new BasicReturnInfo();
            try
            {
                foreach (var pp in publish.ProjectPublishes)
                {
                    try
                    {
                        var reSingle = await ExecFtpPublishAsync(publish, pp);
                        if (reSingle.Success())
                        {
                            continue;
                        }

                        re.FromBasic(reSingle);

                        return re;
                    }
                    catch (Exception ex)
                    {
                        var msg = $"[{pp.ProjectName}]FTP发布异常:{ex.Message}";
                        await log.ErrorAsync(ex.Message, ex, typeof(FTPService).Name, "ExecFtpPublish", handleId);
                        publish.CallbackExecProject(pp, ProgressStatus.AfterExec, msg);

                        return re;
                    }
                }
            }
            catch (Exception ex)
            {
                var innerEx = ex.GetLastInnerException();
                re.SetFailureMsg(innerEx.Message, innerEx.StackTrace);
                var msg = $"FTP发布异常:{innerEx.Message}";
                await log.ErrorAsync(innerEx.Message, innerEx, typeof(FTPService).Name, "ExecFtpPublish", handleId);
                publish.CallbackExecProject(null, ProgressStatus.AfterExec, msg);
            }
            finally
            {
                ftpWrap.Close();
                ftpWrap.Dispose();
            }

            return re;
        }

        /// <summary>
        /// 异步执行FTP发布
        /// </summary>
        /// <param name="publish">发布信息</param>
        /// <param name="projectPublish">项目发布</param>
        /// <returns>任务</returns>
        private async Task<BasicReturnInfo> ExecFtpPublishAsync(PublishInfo publish, ProjectPublishInfo projectPublish)
        {
            var re = new BasicReturnInfo();

            // 先读取该项目所有的文件二进制
            foreach (var file in projectPublish.PublishFiles)
            {
                file.FileMD5 = file.FileFullName.GetFileMD5();
            }

            foreach (var pm in projectPublish.ProjectMachines)
            {
                var ftp = ftpWrap.GetCanUseFtpAsync(pm.Machine).Result;
                var thisSuccess = true;
                var head = $"项目[{projectPublish.ProjectName}]物理机[{pm.Machine.Ip}]";

                // 如果需要先备份
                List<FtpResult> ftpResult = null;
                if (projectPublish.SourceCode.BeforeDeployBak)
                {
                    var msg = $"{head}本地开始备份...";
                    await log.InfoAsync(msg, null, typeof(FTPService).Name, "ExecFtpPublish", handleId);
                    publish.OnCallbackExecProject(projectPublish, ProgressStatus.Execing, msg);
                    var bakFolder = $"{AppContext.BaseDirectory}/_bak/{projectPublish.ServerName}/{projectPublish.ProjectName}/{pm.Machine.Ip}_{pm.Machine.Port}/{DateTimeExtensions.Now.ToString("yyyyMMdd_hhmmss")}";
                    if (!Directory.Exists(bakFolder))
                    {
                        Directory.CreateDirectory(bakFolder);
                    }
                    ftpResult = ftp.DownloadDirectory(bakFolder, pm.Projectdeploy.ProjectDeployPath, FtpFolderSyncMode.Update, FtpLocalExists.Overwrite, progress: ftpProgress =>
                    {
                        var msg = $"{head}:{ftpProgress.RemotePath} 下载:{Math.Round(ftpProgress.Progress, 1)}%";
                        log.InfoAsync(msg, null, typeof(FTPService).Name, "ExecFtpPublish", handleId);

                        publish.OnCallbackExecFileDesc(projectPublish, ftpProgress.Progress >= 100 ? ProgressStatus.AfterExec : ProgressStatus.Execing, msg, ftpProgress.RemotePath, ftpProgress.Progress);
                    });
                    var successCount = ftpResult.Where(p => p.IsDownload && p.IsSuccess).Count();
                    var failures = ftpResult.Where(p => !p.IsDownload || p.IsFailed).ToList();
                    msg = $"{head}本地已备份完.文件总数:{ftpResult.Count}:成功:{successCount}.失败:{failures.Count}";
                    if (failures.Count == 0)
                    {
                        await log.InfoAsync(msg + ".备份路径:" + bakFolder, null, typeof(FTPService).Name, "ExecFtpPublish", handleId);
                    }
                    else
                    {
                        var erMsg = $"{msg + ".备份路径:" + bakFolder}.失败文件:" + failures.Select(p => p.Name).ToArray().ToMergeString(",");
                        await log.WranAsync(erMsg, null, typeof(FTPService).Name, "ExecFtpPublish", handleId);
                    }

                    publish.OnCallbackExecProject(projectPublish, ProgressStatus.Execing, msg);
                }

                // 先将服务器的版本文件下载下来
                var remoteFileVerName = $"{pm.Projectdeploy.ProjectDeployPath}/{projectPublish.VersionFile}";
                var localVerFile = $"{projectPublish.SourceCode.PublishOutPath}/{projectPublish.VersionFile}";
                var verFtpStatus = ftp.DownloadFile(localVerFile, remoteFileVerName, FtpLocalExists.Overwrite);
                IDictionary<string, string> dicFileVer = null;
                if (verFtpStatus == FtpStatus.Success)
                {
                    dicFileVer = localVerFile.ReaderFromFileVer();
                }
                else
                {
                    dicFileVer = new Dictionary<string, string>(projectPublish.PublishFiles.Length);
                    var msg = $"{head}FTP下载[{remoteFileVerName}]失败,可能不存在,但不影响主流程";
                    await log.WranAsync(msg, null, typeof(FTPService).Name, "ExecFtpPublish", handleId);
                    publish.OnCallbackExecProject(projectPublish, ProgressStatus.Execing, msg);
                }

                var isUpdatedRemoveFile = false; // 是否更新过远程文件
                foreach (var f in projectPublish.PublishFiles)
                {
                    var targetFile = $"{pm.Projectdeploy.ProjectDeployPath}/{f.FileName}";
                    // 如果非全量，则判断版本是否需要更新
                    if (!projectPublish.SourceCode.IsFullUpdate && !dicFileVer.IsFileNeedUpdate(targetFile, f.FileMD5))
                    {
                        continue;
                    }
                    isUpdatedRemoveFile = true;
                    FtpStatus ftpStatus = FtpStatus.Success;
                    try
                    {
                        ftpStatus = ftp.UploadFile(localPath: f.FileFullName, remotePath: targetFile, existsMode: FtpRemoteExists.Overwrite, createRemoteDir: true,
                           progress: (ftpProgress)=>
                           {
                               var msg = $"{head}:{ftpProgress.RemotePath} 上传:{Math.Round(ftpProgress.Progress, 1)}%";
                               log.InfoAsync(msg, null, typeof(FTPService).Name, "ExecFtpPublish", handleId);

                               publish.OnCallbackExecFileDesc(projectPublish, ftpProgress.Progress >= 100 ? ProgressStatus.AfterExec : ProgressStatus.Execing, msg, ftpProgress.RemotePath, ftpProgress.Progress);
                           });
                    }
                    catch (Exception ex)
                    {
                        var innerEx = ex.GetLastInnerException();
                        var exMsg = $"{head}上传文件异常:目标文件{targetFile},{innerEx.Message}";
                        await log.ErrorAsync(exMsg, innerEx, typeof(FTPService).Name, handleId, "ExecFtpPublish");

                        publish.OnCallbackExecProject(projectPublish, ProgressStatus.AfterExec, exMsg);

                        return re;
                    }

                    if (ftpStatus == FtpStatus.Success)
                    {
                        // 上传成功，则更新该文件为最新MD5
                        dicFileVer.SetFileVer(targetFile, f.FileMD5);

                        continue;
                    }

                    thisSuccess = false;
                    var msg = $"{head}文件[{targetFile}]上传失败:{ftpStatus}";
                    await log.WranAsync(msg, null, typeof(FTPService).Name, "ExecFtpPublish", handleId);

                    publish.OnCallbackExecProject(projectPublish, ProgressStatus.AfterExec, msg);

                    re.SetFailureMsg(msg);

                    break;
                }

                if (thisSuccess)
                {
                    if (isUpdatedRemoveFile)
                    {
                        // 所有文件上传成功，最后将最新的文件版本文件上传上去
                        var verJson = dicFileVer.ToJsonString();
                        var uploadFtpVerStatus = ftp.UploadBytes(Encoding.UTF8.GetBytes(verJson), remoteFileVerName, FtpRemoteExists.Overwrite, true);
                        if (uploadFtpVerStatus == FtpStatus.Success)
                        {
                            var msg = $"{head}FTP发布成功";
                            await log.InfoAsync(msg, null, typeof(FTPService).Name, "ExecFtpPublish", handleId);

                            publish.OnCallbackExecProject(projectPublish, ProgressStatus.AfterExec, msg);
                        }
                        else
                        {
                            var msg = $"{head}FT发布成功，但上传文件版本文件失败";
                            await log.WranAsync(msg, null, typeof(FTPService).Name, "ExecFtpPublish", handleId);

                            publish.OnCallbackExecProject(projectPublish, ProgressStatus.AfterExec, msg);
                        }
                    }
                    else
                    {
                        var msg = $"{head}FTP发布成功，没有任何可更新的文件";
                        await log.InfoAsync(msg, null, typeof(FTPService).Name, "ExecFtpPublish", handleId);

                        publish.OnCallbackExecProject(projectPublish, ProgressStatus.AfterExec, msg);
                    }
                }
                else
                {
                    var msg = $"{head}FTP发布失败";
                    await log.WranAsync(msg, null, typeof(FTPService).Name, "ExecFtpPublish", handleId);

                    publish.OnCallbackExecProject(projectPublish, ProgressStatus.AfterExec, msg);
                }
            }
            projectPublish.PublishFiles = null;

            return re;
        }
    }
}
