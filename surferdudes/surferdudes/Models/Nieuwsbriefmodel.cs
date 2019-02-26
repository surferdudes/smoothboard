using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace surferdudes.Models
{
    public class Nieuwsbriefmodel
    {
        public int ID { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Geslacht { get; set; }
        public string Land { get; set; }
        public string Email { get; set; }

        public void SendMessage(String email, String subject, String body)
        {
            //SMTP server en poort 587
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential("usermail", "userpassword");
            smtpClient.EnableSsl = true;
            //Gmail werkt met Securityprotocol TLS
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            //smtpClient.UseDefaultCredentials = false;

            MailMessage mail = new MailMessage();
            mail.Body = "body";
            mail.IsBodyHtml = true;
            //Setting From , To and CC
            mail.From = new MailAddress("email", "name");
            mail.To.Add(new MailAddress("surfdudes2019@gmail.com"));

            smtpClient.Send(mail);
        }
    }
}

