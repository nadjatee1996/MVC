using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wb.Models;
using System.Text.RegularExpressions;

namespace wb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private wbDBEntities1 db = new wbDBEntities1();
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
        public ActionResult Register([Bind(Include = "pseudonym,password,email")] user user)
        {
            string errorString = "<div id='regError'>";
            string userName = Request["pseudonym"];
            string password = Request["password"];
            string passwordConfirm = Request["passwordConfirm"];
            string email = Request["email"];
            string agree = Request["agree"];
            bool confirm = true;
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
            if (password != passwordConfirm)
            {
                errorString += "</br><span>Your passwords don't match.</span>";
                confirm = false;
            }
            if (password.Length == 0)
            {
                errorString += "</br><span>You did not enter a password.</span>";
                confirm = false;
            }
            else if (password.Length <= 3)
            {
                errorString += "</br><span>Your password is too short.</span>";
                confirm = false;
            }
            if (agree == "false")
            {
                errorString += "</br><span>Please agree to our <a href='terms'>Terms and Agreements</a> to register.</span>";
                confirm = false;
            }
            errorString += " " + password + "/";
            errorString += "</div>";
            ViewBag.Errors = errorString;
            if ((ModelState.IsValid) && (confirm == true))
            {
                db.users.Add(user);
                db.SaveChanges();
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
        public ActionResult Login(string username,string password, bool remember)
        {
            ViewData["username"] = username;
            ViewData["password"] = password;
            ViewData["remember"] = remember;
            return View("Index");
        }
    }
}