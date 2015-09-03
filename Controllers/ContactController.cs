using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wb.Models;

namespace wb.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string feedback)
        {
            ViewData["feedback"] = feedback;
            return View("Contact");
        }
    }
}