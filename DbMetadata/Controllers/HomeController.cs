﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DbMetadata.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbMetadata.Controllers
{
    public class HomeController : Controller
    {
        private MetadataContext db;
        public HomeController(MetadataContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Organization()
        {
            return RedirectToAction("Index", "OrganizationsController");
        }

        public IActionResult Department()
        {
            return RedirectToAction("Index", "DepartmentsController");
        }

        public IActionResult Project()
        {
            return RedirectToAction("Index", "ProjectsController");
        }
    }
}
