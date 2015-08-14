﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public ActionResult registerAction(string regUser, string regPass, string regPassConfirm,string regEmail, bool regAgree)
        {
            ViewData["regUser"] = regUser;
            ViewData["regPass"] = regPass;
            ViewData["regPassConfirm"] = regPassConfirm;
            ViewData["regEmail"] = regEmail;
            ViewData["regAgree"] = regAgree;
            return View("Register");
        }

        public ActionResult Contact()
        {
            return View("Contact");
        }
    }
}