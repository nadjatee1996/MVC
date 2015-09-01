using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using wb.Models;
using System.Text.RegularExpressions;
using System.Data.Entity;

namespace wb.Controllers
{
    public class HomeController : Controller
    {

        private wbEntities db = new wbEntities();

        // GET: Home        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "pseudonym,password,passwordConfirm,agree")] register register)
        {
            string errorString = "<div id='regError'>";
            string userName = Request["pseudonym"];
            string pword = Request["password"];
            string passwordConfirm = Request["passwordConfirm"];
            string agree = Request["agree"];
            bool confirm = true;
            Regex r = new Regex("^[a-zA-Z_]*$");
            if(!r.IsMatch(userName))
            {
                errorString += "<span>Your psuedonym has invalid characters.</span>";
                confirm = false;
            }
            if (db.users.Any(p => p.pseudonym == userName))
            {
                errorString += "<span>Your psuedonym is already taken. Please choose another.</span>";
                confirm = false;
            }
            if (userName.Length == 0)
            {
                errorString += "<span>You did not enter a pseudonym.</span>";
                confirm = false;
            }
            else if (userName.Length >= 20)
            {
                errorString += "<span>Your pseudonym is too long.</span></br>";
                confirm = false;
            }
            else if ((userName.Length < 3) && (userName.Length > 0))
            {
                errorString += "<span>Your pseudonym is too short.</span></br>";
                confirm = false;
            }
            else if (Regex.IsMatch(userName, "/^[a-zA-Z0-9_-]*$/"))
            {
                errorString += "<span>Your pseudonym has one or more invalid character(s).</span>";
                confirm = false;
            }
            if (pword != passwordConfirm)
            {
                errorString += "</br><span>Your passwords don't match.</span>";
                confirm = false;
            }
            if (pword.Length == 0)
            {
                errorString += "</br><span>You did not enter a password.</span>";
                confirm = false;
            }
            else if (pword.Length <= 3)
            {
                errorString += "</br><span>Your password is too short.</span>";
                confirm = false;
            }
            if (agree == "false")
            {
                errorString += "</br><span>Please agree to our <a href='terms'>Terms and Agreements</a> to register.</span>";
                confirm = false;
            }
            errorString += "</div>";
            ViewBag.Errors = errorString;

            if ((ModelState.IsValid) && (confirm == true))
            {

                using (db)
                {
                    user user = new user();
                    user.pseudonym = userName;
                    user.password = DataSec.hashMD5(pword);
                    user.regIP = "unknown";
                    user.loginIP = "unknown";
                    user.key = "default";
                    if (System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != "")
                    {
                        user.regIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; ;
                        user.loginIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; ;
                    }
                    db.users.Add(user);
                    db.SaveChanges();                        
                }


                return RedirectToAction("Index");
            }  
            return View("Register");
        }

        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(string feedback)
        {
            ViewData["feedback"] = feedback;
            return View("Contact");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "pseudonym,password,remember")] register register)
        {
            string userName = Request["pseudonym"];
            string password = Request["password"];
            string remember = Request["remember"];

            user result = (from user in db.users where 
                        user.pseudonym == userName
                        select user).First();
            if(DataSec.hashMD5(password) == result.password)
            {
                string cookieData = DataSec.secure(userName);
                Response.Cookies["session_id"].Value = cookieData;
                if(remember != "false")
                {
                    Response.Cookies["session_id"].Expires = DateTime.Now.AddMonths(1);
                }
                result.key = cookieData;
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
            }

            return View("Index");
        }
    }
}