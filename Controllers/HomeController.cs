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