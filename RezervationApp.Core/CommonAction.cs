using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ReservationApp.Core
{
    public class CommonAction
    {
        public void SendMail(string konu, string icerik, string mailAdresi )
        {
            MailMessage mesaj = new MailMessage();
            mesaj.From = new MailAddress("isefaozdemir@gmail.com");
            mesaj.To.Add(mailAdresi);
            mesaj.Subject = konu;
            mesaj.Body = icerik;

            SmtpClient a = new SmtpClient();
            a.Credentials = new System.Net.NetworkCredential("x@gmail.com", "xxx");
            a.Port = 587;
            a.Host = "smtp.gmail.com";
            a.EnableSsl = true;
            object userState = mesaj;

            try
            {
                a.SendAsync(mesaj, (object)mesaj);
                //log
            }

            catch (SmtpException ex)
            {
                //log
            }

        }
    }
}
