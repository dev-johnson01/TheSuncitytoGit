using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Suncity.Models;

namespace Suncity.Controllers
{
    public class AgentAccountController : Controller
    {
        // GET: AgentAccount
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult AgentRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgentRegistration(Agent agent)
        {            
                if (ModelState.IsValid)
                {
                    
                    using (var Context = new SuncityDatabase())
                    {
                        Agent usr = Context.Agents.FirstOrDefault(record => record.Email == agent.Email);
                        if (usr != null)
                        {
                          ViewBag.error = usr.Email + " account already exist";
                        }
                        else 
                        {
                            Context.Agents.Add(agent);
                            Context.SaveChanges();
                            ViewBag.alert = "Successfully Registered Check your mail for further information";
                            ModelState.Clear();
                        }
                    
                    }
                
                } 
                
            return View();
        }

        
        public ActionResult AgentRecord()
        {
            ViewBag.title = "Customer Record";

            using (var context = new SuncityDatabase())
            {
                var agents = (from row in context.Agents orderby row.AgentId descending select row).ToList();
                return View(agents);
            }

        }

        //Get
       public ActionResult AgentLogin()
        {
            return View();
        }

        [HttpPost]
        ActionResult AgentLogin(Agent agent)
        {
            using (var context = new SuncityDatabase())
            {
                Agent usr = context.Agents.SingleOrDefault(record => record.Email == agent.Email && record.Password == agent.Password);

                if (usr != null)
                {
                    Session["UserId"] = usr.AgentId.ToString();
                    Session["Email"] = usr.Email.ToString();
                    Session["FirstName"] = usr.FirstName.ToString();

                    if (Session["Email"].ToString() == "suncityrenewableenergy@gmail.com")
                    {
                        return RedirectToAction("AgentRecord");
                    }
                    else
                    {
                        return RedirectToAction("AgentProfile");
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Invalid Email or Password");
                }
            }//End Using
            return View();
        }

        public ActionResult AgentProfile()
        {
            if (Session["id"] != null)
            {
                using (var context = new SuncityDatabase())
                {
                    string user_Id = Session["id"].ToString();
                    var user = context.Agents.Single(row => row.AgentId.ToString() == user_Id);

                    return View(user);
                }
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
    }
}