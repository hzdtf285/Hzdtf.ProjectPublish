using FluentFTP;
using Hzdtf.PublishProject.Model.Server;
using Hzdtf.Utility.Safety;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.ProjectPublish.FTP.Wrap
{
    /// <summary>
    /// FTP包装
    /// @ 黄振东
    /// </summary>
    public class FTPWrap : IFTPWrap
    {
        /// <summary>
        /// FTP缓存，key：IP+端口, value：FTP客户端
        /// </summary>
        private static readonly IDictionary<string, FtpClient> cache = new Dictionary<string, FtpClient>();

        /// <summary>
        /// 同步FTP缓存
        /// </summary>
        private static readonly object syncCache = new object();

        /// <summary>
        /// 异步获取一个可用的FTP客户端
        /// </summary>
        /// <param name="machine">物理机</param>
        /// <returns>任务</returns>
        public async Task<FtpClient> GetCanUseFtpAsync(ServerInfo.Machine machine)
        {
            FtpClient ftp = null;
            var key = $"{machine.Ip}:{machine.Port}";
            if (cache.ContainsKey(key))
            {
                return cache[key];
            }
            try
            {
                var pwd = machine.Encrypt ? DESUtil.Decrypt(machine.Password) : machine.Password;
                ftp = new FtpClient();
                ftp.Host = machine.Ip;
                ftp.Port = machine.Port;
                ftp.Credentials = new NetworkCredential(machine.User, pwd);
                await ftp.ConnectAsync();

                lock (syncCache)
                {
                    if (cache.ContainsKey(key))
                    {
                        ftp.DisconnectAsync();
                        return cache[key];
                    }
                    cache.Add(key, ftp);
                }

                machine.CanConnection = true;
                machine.Status = "连接成功";
            }
            catch (Exception ex)
            {
                machine.CanConnection = false;
                machine.Status = ex.Message;
            }

            return ftp;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            foreach (var ftp in cache)
            {
                ftp.Value.Disconnect();
            }
            cache.Clear();
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Close();
        }
    }
}
