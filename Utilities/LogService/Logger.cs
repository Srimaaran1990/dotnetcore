using System;
using System.Text;
using System.Configuration;
using System.IO;
using System.Web;
using Common.Utils;
using System.Net;
using System.Security.Principal;

namespace Common.LogService
{

    public static class IpayLogger
    {
 
        ///<summary>
        /// FUNCTION NAME: ExportGridToExcel
        /// PARAMETER:     No Parameter
        /// RETURN:        No Returns
        /// DESCRIPTION:   This function will Export the Grid View Data into Excel Sheet.
        ///</summary> 
        ///
        public static void CreateLog(string LogFileName, Exception ex)
        {


            int code = ex.HResult;


            {

                string SPath = "";
                FileInfo fi = new FileInfo(SPath);
                if (!File.Exists(SPath))
                {
                    File.Create(SPath);
                }
                FileStream file;
                file = new FileStream(Path.GetFullPath(SPath), FileMode.Append, FileAccess.Write);
                if (file != null)
                {
                    StreamWriter sw = new StreamWriter(file);
                    string hostName = Dns.GetHostName(); // Retrive the Name of HOST
                    string ipAddress = Dns.GetHostByName(hostName).AddressList[0].ToString(); ;
                    
                    string strMsg = DateTime.Now.ToString() + " \r\n \r\n IP Address :\r\n \r\n " + ipAddress + " \r\n \r\n Source :\r\n \r\n " + ex.Source + "\r\n\r\nMessage :\r\n\r\n " + ex.Message + "\r\n\r\nStackTrace : " + ex.StackTrace + "\r\n\r\n Inner Exception :" + ex.InnerException + "\r\n\r\n Data :" + ex.Data + "\r\n\r\n";
                    sw.WriteLine(strMsg);
                    sw.Close();
                    sw.Dispose();
                    file.Close();
                    file.Dispose();
                    sw = null;
                    file = null;
                    if (code != -2147467259)
                    {
                       // SendErrorLog(strMsg);
                    }

                }

            }


        }

        //public static void DbCreateLog(string LogFileName, DbEntityValidationException ex)
        //{
        //    string hostName = Dns.GetHostName(); // Retrive the Name of HOST
        //    string ipAddress = Dns.GetHostByName(hostName).AddressList[0].ToString(); 
        //    object LockObj = new object();
        //    lock (LockObj)
        //    {

        //        System.IO.FileStream FS = null;
        //        try
        //        {
        //            FS = System.IO.File.Open(LogFileName, System.IO.FileMode.OpenOrCreate | System.IO.FileMode.Append);

        //            string err = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.") + DateTime.Now.Millisecond + "\r\n";
        //            byte[] bErr = System.Text.Encoding.Default.GetBytes(err);
        //            FS.Write(bErr, 0, bErr.Length);

        //            StringBuilder sb = new StringBuilder();
        //            foreach (var eve in ex.EntityValidationErrors)
        //            {
        //                sb.AppendLine(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
        //                                                eve.Entry.Entity.GetType().Name,
        //                                                eve.Entry.State));
        //                foreach (var ve in eve.ValidationErrors)
        //                {
        //                    sb.AppendLine(string.Format("- Property: \"{0}\", Error: \"{1}\"",
        //                                                ve.PropertyName,
        //                                                ve.ErrorMessage));
        //                }
        //            }


        //            FileInfo fi = new FileInfo(LogFileName);
        //            if (!File.Exists(LogFileName))
        //            {
        //                File.Create(LogFileName);
        //            }
        //            FileStream file;
        //            file = new FileStream(Path.GetFullPath(LogFileName), FileMode.Append, FileAccess.Write);
        //            if (file != null)
        //            {
        //                StreamWriter sw = new StreamWriter(file);


             
        //                string strMsg = DateTime.Now.ToString() + " \r\n \r\n IP Address :\r\n \r\n " + ipAddress + " \r\n \r\n Error Detail :\r\n \r\n " + sb.ToString() + " \r\n \r\n Source :\r\n \r\n " + ex.Source + "\r\n\r\nMessage :\r\n\r\n " + ex.Message + "\r\n\r\nStackTrace : " + ex.StackTrace + "\r\n\r\n Inner Exception :" + ex.InnerException + "\r\n\r\n Data :" + ex.Data + "\r\n\r\n";
        //                sw.WriteLine(strMsg);
        //                sw.Close();
        //                sw.Dispose();
        //                file.Close();
        //                file.Dispose();
        //                sw = null;
        //                file = null;
        //                SendErrorLog(strMsg);

        //            }
        //            SendErrorLog(sb.ToString());

        //        }
        //        finally
        //        {
        //            if (FS != null)
        //                FS.Close();
        //        }
        //    }

        //}


        //public static void SendErrorLog(string sb)
        //{
        //    MailListDup mail = new MailListDup();
        //    string strErrorAlertEmail = ConfigurationManager.AppSettings["ErrorAlertEmailID"];
        //    mail.strToEmilId = strErrorAlertEmail;
        //    mail.strEmailBody = sb.ToString();
        //    Utilities.SendMail(mail);
        //}
 
    }
}
