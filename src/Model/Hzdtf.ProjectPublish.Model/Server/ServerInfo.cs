using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hzdtf.Utility.Utils;

namespace Hzdtf.PublishProject.Model.Server
{
    /// <summary>
    /// 服务器信息
    /// @ 黄振东
    /// </summary>
    public class ServerInfo
    {
        /// <summary>
        /// 服务器数组
        /// </summary>
        public Server[] Servers { get; set; }

        /// <summary>
        /// 根据服务器名称获取服务器
        /// </summary>
        /// <param name="serverName">服务器名称</param>
        /// <returns>服务器</returns>
        public Server GetServerByName(string serverName)
        {
            if (string.IsNullOrWhiteSpace(serverName) || Servers.IsNullOrLength0())
            {
                return null;
            }

            return Servers.Where(p => p.ServerName == serverName).FirstOrDefault();
        }

        /// <summary>
        /// 服务器
        /// @ 黄振东
        /// </summary>
        public class Server
        {
            /// <summary>
            /// 服务器ID
            /// </summary>
            public int ServerId { get; set; }

            /// <summary>
            /// 服务器名称
            /// </summary>
            public string ServerName { get; set; }

            /// <summary>
            /// 物理机数组
            /// </summary>
            public Machine[] Machines { get; set; }
        }

        /// <summary>
        /// 物理机
        /// @ 黄振东
        /// </summary>
        public class Machine
        {
            /// <summary>
            /// 物理机ID
            /// </summary>
            public int MachineId { get; set; }

            /// <summary>
            /// IP
            /// </summary>
            public string Ip { get; set; }

            /// <summary>
            /// 端口
            /// </summary>
            public int Port { get; set; }

            /// <summary>
            /// 用户
            /// </summary>
            public string User { get; set; }

            /// <summary>
            /// 是否加密
            /// </summary>
            public bool Encrypt { get; set; }

            /// <summary>
            /// 密码
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// 状态
            /// </summary>
            public string Status
            {
                get;
                set;
            }

            /// <summary>
            /// 是否能连接
            /// </summary>
            public bool? CanConnection
            {
                get;
                set;
            }
            
            /// <summary>
            /// 是否选中
            /// </summary>
            public bool Selected
            {
                get;
                set;
            }
        }
    }
}
