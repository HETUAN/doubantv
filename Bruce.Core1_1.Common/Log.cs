using System;
using System.IO;
using System.Text;

namespace Bruce.Core1_1.Common
{
    /// <summary>
    /// 记录日志
    /// </summary>
    public static class Log
    {
        #region 记录日志
        /// <summary>
        /// 日志路径
        /// </summary>
        private static string _logPath = Path.Combine(AppContext.BaseDirectory, "log");

        /// <summary>
        /// 获取日志文件路径
        /// </summary>
        /// <returns></returns>
        private static string GetPath(string type)
        {
            try
            {
                if (!Directory.Exists(_logPath))
                {
                    Directory.CreateDirectory(_logPath);
                }
                string path = Path.Combine(_logPath, type + DateTime.Now.ToString("yyyyMMdd") + ".log");
                if (!File.Exists(path))
                {
                    StreamWriter sw = File.CreateText(path);
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                    sw.Flush();
                }
                return path;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="msg">内容</param>
        public static void Error(string msg)
        {
            try
            {
                using (var fileStream = File.Open(GetPath("error"), FileMode.Append, FileAccess.Write))
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(string.Format("ERROR:{0} \n\r {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ffff"), msg));
                    streamWriter.Flush();
                }
                Console.WriteLine(msg);
                //StreamWriter sw = File.AppendText(GetPath("error"));
                ////StreamWriter sw = new StreamWriter(GetPath("error"), true, Encoding.Default);
                //sw.WriteLine(string.Format("ERROR:{0} \n\r {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ffff"), msg));
                //sw.Flush();
                ////sw.Close();
                //Console.WriteLine(msg);
            }
            catch
            { }
        }

        /// <summary>
        /// 正常日志
        /// </summary>
        /// <param name="msg">内容</param>
        public static void Info(string msg)
        {
            try
            {
                using (var fileStream = File.Open(GetPath("info"), FileMode.Append, FileAccess.Write))
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(string.Format("INFO:{0} \n\r {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ffff"), msg));
                    streamWriter.Flush();
                }
                Console.WriteLine(msg);

                //StreamWriter sw = File.AppendText(GetPath("info"));
                ////StreamWriter sw = new StreamWriter(GetPath("info"), true, Encoding.Default);
                //sw.WriteLine(string.Format("INFO:{0} \n\r {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ffff"), msg));
                //sw.Flush();
                ////sw.Close();
                //Console.WriteLine(msg); 
            }
            catch
            { }
        }

        #endregion
    }

}
