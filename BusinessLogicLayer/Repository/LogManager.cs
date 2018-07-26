using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class LogManager
    {
        private static string _logPath=Convert.ToString(ConfigurationManager.AppSettings["LogPath"]);
        public LogManager() {
        }

        #region Write log to file
        public static void WriteLog(Exception ex) {
            FileStream fileStream;
            FileInfo logFileInfo = new FileInfo(_logPath + "Log-" + DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt");
            DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(_logPath + "Log-" + DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt", FileMode.Append);
            }
            using (StreamWriter log = new StreamWriter(fileStream)) {
                log.WriteLine($"~~~~~~~ Stat Date {DateTime.Now} ~~~~~~~~~");
                log.WriteLine($"Error Source {ex.Source}");
                log.WriteLine($"Inner InnerException {ex.InnerException}");
                log.WriteLine($"Error Message {ex.Message}");
                log.WriteLine($"Error TargetSite {ex.TargetSite}");
                log.WriteLine($"~~~~~~~ End Date {DateTime.Now} ~~~~~~~~~");
            }
        }
        #endregion
    }
}
