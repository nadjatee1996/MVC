﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wb.Controllers
{
    public class TopicController : Controller
    {
        // GET: Topic
        public ActionResult Index()
        {
            return View();
        }
    }
}