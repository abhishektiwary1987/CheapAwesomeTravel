using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace WebApplication1
{
    public class LogUtility
    {
        public static void WriteLog(string inputParam)
        {
            string filepath = System.IO.Directory.GetCurrentDirectory();
            string filefullpath = filepath + "\\wwwroot\\JsonLog\\";
            string filename = "JsonLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            try
            {
                StreamWriter sw = new StreamWriter(filefullpath + filename);
                sw.WriteLine(inputParam);
                sw.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        public static void GlobalErrorLog(string inputParam)
        {
            string filepath = System.IO.Directory.GetCurrentDirectory();
            string filefullpath = filepath + "\\wwwroot\\ErrorLogging\\";
            string filename = "ErrorLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            try
            {
                StreamWriter sw = new StreamWriter(filefullpath + filename);
                sw.WriteLine(inputParam);
                sw.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
    }
}
