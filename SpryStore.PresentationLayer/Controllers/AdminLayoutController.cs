﻿using Microsoft.AspNetCore.Mvc;
using System;

namespace SpryStore.PresentationLayer.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            Random rnd = new Random();
            int number = rnd.Next(0,100);
            ViewBag.number = number;
            return View();
        }
    }
}
