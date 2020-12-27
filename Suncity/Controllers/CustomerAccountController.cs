using Suncity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Suncity.Controllers
{
    public class CustomerAccountController : Controller
    {
        // GET: CustomerAccount
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registration(Customer customer )
        {
            ViewBag.Title = "Register";

            if (ModelState.IsValid)
            {
                using (var context = new SuncityDatabase())
                {
                    Customer usr = context.Customers.FirstOrDefault(record => record.Email == customer.Email);
                    if (usr != null)
                    {
                        ViewBag.error = usr.Email + " account already exist";
                        return View();
                    }

                    else
                    {
                        customer.DateRegistered = DateTime.Now;
                        context.Customers.Add(customer);
                        context.SaveChanges();
                        ViewBag.Registered = "Succeccfully Registered";
                        ModelState.Clear();
                    }
                    

                }
                
            }
            return View();

        }
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer customer)  
        {
            using (var context = new SuncityDatabase())
            {
               Customer usr = context.Customers.SingleOrDefault(record => record.Email == customer.Email && record.Password == customer.Password);

                if (usr != null)
                {
                    Session["UserId"] = usr.CustomerId.ToString();
                    Session["Email"] = usr.Email.ToString();
                    Session["FirstName"] = usr.FirstName.ToString();

                    if (Session["Email"].ToString() == "suncityrenewableenergy@gmail.com")
                    {
                        return RedirectToAction("CustomerRecord");
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Invalid Email or Password");
                }
            }//End Using

            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("index", "Home");
        }



        public ActionResult CustomerRecord()
        {
            ViewBag.title = "Customer Record";

            using (var context = new SuncityDatabase())
            {
                var customers = (from row in context.Customers orderby row.DateRegistered descending select row).ToList();
                return View(customers);
            }

        }

        public ActionResult DeleteCustomer(int?id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            using (var context = new SuncityDatabase())
            {
                Customer customer = context.Customers.Single(row => row.CustomerId == id);
                return View(customer);
            }
        }
        [HttpPost]
        [ActionName("DeleteCustomer")]
        public ActionResult ConfirmDeleteCustomer(int?id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            using (var context = new SuncityDatabase())
            {
                Customer customer = context.Customers.Single(row => row.CustomerId == id);
                context.Customers.Remove(customer);
                context.SaveChanges();

                return RedirectToAction("CustomerRecord");
            }
           
        }

        public ActionResult EditCustomer(int?id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            using (var context = new SuncityDatabase())
            {
                Customer customer = context.Customers.Single(row => row.CustomerId == id);
                return View(customer);
            }
        }

        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            using (var context = new SuncityDatabase())
            {
                if (customer.CustomerId > 0)
                {
                    var val = context.Customers.Where(record => record.CustomerId == customer.CustomerId).FirstOrDefault();

                    if (val != null)
                    {
                        val.FirstName = customer.FirstName;
                        val.LastName = customer.LastName;
                        val.Email = customer.Email;
                        val.PhoneNumber = customer.PhoneNumber;
                        val.Password = customer.Password;
                        val.ConfirmPassword = customer.ConfirmPassword;
                        

                    }
                }
                else
                {
                    context.Customers.Add(customer);
                }
                context.SaveChanges();
                return RedirectToAction("EmployeeRecord");

            }
        }

    }
}