using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.PublishProject.Model.Publish
{
    /// <summary>
    /// 发布文件信息
    /// @ 黄振东
    /// </summary>
    public class PublishFileInfo
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// 文件全路径
        /// </summary>
        public string FileFullName
        {
            get;
            set;
        }

        /// <summary>
        /// 文件MD5值
        /// </summary>
        public string FileMD5
        {
            get;
            set;
        }
    }
}
