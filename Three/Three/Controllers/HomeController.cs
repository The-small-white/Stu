﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Three.Service;

namespace Three.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IClock clock)
        {

        }
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
