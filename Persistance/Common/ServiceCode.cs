
using System;
namespace Persistence.DbCxt
{
    public class CRUDCommonCode
    {

        public static void SendErrorLog(string strBody, string errorType)
        {
         //   if (ConfigurationManager.AppSettings["EmailFunctionalityNeeded"].ToString() == "True")
            {
                //using (MailMessage message = new MailMessage())
                //{
                //    try
                //    {
                //        message.From = new MailAddress(ConfigurationManager.AppSettings["ErrorAlertEmailID"]);
                //        var emailAddress = ConfigurationManager.AppSettings["EmailTO"].ToString().Split(';').ToArray();
                //        foreach (var rotateEmail in emailAddress)
                //        {
                //            message.To.Add(rotateEmail);
                //        }
                //        message.Subject = ConfigurationManager.AppSettings["ApplicationName"].ToString() + " - " + errorType + " -  Error Alert";
                //        message.Body = strBody;
                //        message.IsBodyHtml = true;
                //        Utilities.SendMailAWS(message);
                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //}
            }
        }

        public static void CreateLog(Exception ex)
        {
            if (ex != null)
            {
                string strMsg = DateTime.Now.ToString() + " Source :\r\n \r\n " + ex.Source + "\r\n\r\nMessage :\r\n\r\n " + ex.Message + "\r\n\r\nStackTrace : " + ex.StackTrace + "\r\n\r\n Inner Exception :" + ex.InnerException + "\r\n\r\n Data :" + ex.Data + "\r\n\r\n";
                SendErrorLog(strMsg, "Screen");
            }
        }

        public static void ProcedureCreateLog(Exception ex)
        {
            if (ex != null)
            {
                string strMsg = DateTime.Now.ToString() + " Source :\r\n \r\n " + ex.Source + "\r\n\r\nMessage :\r\n\r\n " + ex.Message + "\r\n\r\nStackTrace : " + ex.StackTrace + "\r\n\r\n Inner Exception :" + ex.InnerException + "\r\n\r\n Data :" + ex.Data + "\r\n\r\n";
                SendErrorLog(strMsg, "Procedure");
            }
        }
    }
}
