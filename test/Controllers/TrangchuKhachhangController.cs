﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test.Controllers
{
    public class TrangchuKhachhangController : Controller
    {
        // GET: TrangchuKhachhang
        public ActionResult Index()
        {
            if (Session["IsLogin"].Equals(true))
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Login");
           
        }
    }
}