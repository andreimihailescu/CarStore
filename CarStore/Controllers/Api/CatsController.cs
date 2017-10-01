using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Web.Http;

namespace CarStore.Controllers.Api
{
    public class CatsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage File()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new System.IO.FileStream(@"D:\Andrei\GitHub Projects\Car Store\CarStore\CarStore\Content\cat.mp4", System.IO.FileMode.Open);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("video/mp4");

            return response;
        }

        [Route("api/sendmail")]
        [HttpGet]
        public IHttpActionResult SendMail()
        {
            //try
            //{
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 465);

                smtpClient.Credentials = new System.Net.NetworkCredential("email", "password");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();

                //Setting From , To and CC
                mail.From = new MailAddress("myemail@email.com", "MyWeb Site");
                mail.To.Add(new MailAddress("another@email.com"));
                //mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));

                smtpClient.Send(mail);

                return Ok("Mail sent");
            //}
            //catch (Exception)
            //{
            //    return InternalServerError();
            //}
        }
    }
}
