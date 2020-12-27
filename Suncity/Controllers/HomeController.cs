using Suncity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

using SmtpClassLib;

namespace Suncity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Background = "/Content/assets/images/solar-bg2.jpg";
            if(Session["UserId"] != null)
            {
                ViewBag.Login = "Login";
            }
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Background = "/Content/assets/images/solar-bg2.jpg";
            if (Session["UserId"] != null)
            {
                ViewBag.Login = "Login";
            }

            ViewBag.Message = "Your application description page.";
            ViewBag.Background = "/Content/assets/images/ahmad-bg.jpg";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Background = "/Content/assets/images/solar-bg2.jpg";
            if (Session["UserId"] != null)
            {
                ViewBag.Login = "Login";
            }
            ViewBag.Background = "/Content/assets/images/ahmad-bg.jpg";
           

            return View();
        }

        [HttpPost]
       public ActionResult Contact(Contact contact)
        {
            //if all the parameter require in that form is filled corectly
            if (ModelState.IsValid)
            {
                using (MailMessage client = new MailMessage())
                {
                    client.From = new MailAddress(contact.UserEmail, contact.FullName);
                    client.To.Add(Connection.senderEmail);
                    client.Subject = Connection.senderSubject;
                    client.Body = "You have a message from <br/><br/>" + contact.FullName + "<br/><br/>" +
                        "<b>Email:<b>" + contact.UserEmail + "<br/><br/>" + "<b>Message:<b>" + contact.MessageBody;
                    client.IsBodyHtml = true;

                    /*using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(SenderEmail, SenderPass);
                        smtp.EnableSsl = true;
                        smtp.Send(client);
                    }*/
                    Connection.MySmtp(client);
                    ViewBag.message = "Message has been sent";
                    ModelState.Clear();
                }

            }
            
            return View();

        }
        public ActionResult Portfolio()
        {
            ViewBag.Message = "Your Portfolio page.";
            return View();
        }

       public ActionResult BasicPlan()
        {
            ViewBag.Background = "/Content/assets/images/solar-bg2.jpg";
            if (Session["UserId"] != null)
            {
                ViewBag.Login = "Login";
            }

            ViewBag.Message = "Your application description page.";
            ViewBag.Background = "/Content/assets/images/ahmad-bg.jpg";
            return View();
        }

        public ActionResult IntermediatePlan()
        {
            ViewBag.Background = "/Content/assets/images/solar-bg2.jpg";
            if (Session["UserId"] != null)
            {
                ViewBag.Login = "Login";
            }

            ViewBag.Message = "Your application description page.";
            ViewBag.Background = "/Content/assets/images/ahmad-bg.jpg";
            return View();
        }

        public ActionResult PremiumPlan()
        {
            ViewBag.Background = "/Content/assets/images/solar-bg2.jpg";
            if (Session["UserId"] != null)
            {
                ViewBag.Login = "Login";
            }

            ViewBag.Message = "Your application description page.";
            ViewBag.Background = "/Content/assets/images/ahmad-bg.jpg";
            return View();
        }
    }
}