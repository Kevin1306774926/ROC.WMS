using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using System.IO;
using System.Web;

namespace ROC.Core
{
    public class NLog
    {

        public static string LogFile { get; set; }
        public static Logger logger = LogManager.GetCurrentClassLogger();

        static NLog()
        {
            LogFile = Path.Combine(HttpRuntime.AppDomainAppPath, "log.txt");
        }
        public static void Log(Exception ex)
        {
            using (System.IO.StreamWriter w = System.IO.File.CreateText(LogFile))
            {
                w.Write("{0}: ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                w.WriteLine(ex.Message);
                w.WriteLine(ex.TargetSite);
                w.WriteLine(ex.Source);
                w.WriteLine(ex.InnerException);
                w.WriteLine(ex.StackTrace);

                w.Flush();
                w.Close();
            }
        }

        public static void Log(string msg)
        {

            using (System.IO.StreamWriter w = System.IO.File.CreateText(LogFile))
            {
                w.Write("{0}: ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                w.WriteLine(msg);
                // Close the writer and underlying file.
                w.Flush();
                w.Close();
            }
        }
    }
}
