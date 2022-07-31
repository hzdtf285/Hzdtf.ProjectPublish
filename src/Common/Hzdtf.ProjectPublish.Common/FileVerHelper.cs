using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hzdtf.Utility.Utils;

namespace System
{
    /// <summary>
    /// 文件版本帮助类
    /// @ 黄振东
    /// </summary>
    public static class FileVerHelper
    {
        /// <summary>
        /// 根据文件版本读取文件映射版本的字典
        /// key：文件名；value：文件内容MD5
        /// </summary>
        /// <param name="fileVerName">文件版本名</param>
        /// <returns>文件映射版本的字典</returns>
        public static IDictionary<string, string> ReaderFromFileVer(this string fileVerName)
        {
            return fileVerName.ToJsonObjectFromFile<IDictionary<string, string>>();            
        }

        /// <summary>
        /// 判断文件是否需要更新
        /// </summary>
        /// <param name="oldDicFileVer">旧的文件版本字典</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileMD5">文件MD5</param>
        /// <returns>文件是否需要更新</returns>
        public static bool IsFileNeedUpdate(this IDictionary<string, string> oldDicFileVer, string fileName, string fileMD5)
        {
            if (oldDicFileVer.IsNullOrCount0() || !oldDicFileVer.ContainsKey(fileName))
            {
                return true;
            }

            return !fileMD5.Equals(oldDicFileVer[fileName]);
        }

        /// <summary>
        /// 设置文件版本
        /// </summary>
        /// <param name="dicFileVer">文件版本字典</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileMD5">文件MD5</param>
        public static void SetFileVer(this IDictionary<string, string> dicFileVer, string fileName, string fileMD5)
        {
            if (dicFileVer.ContainsKey(fileName))
            {
                dicFileVer[fileName] = fileMD5;
            }
            else
            {
                dicFileVer.Add(fileName, fileMD5);
            }
        }
    }
}
