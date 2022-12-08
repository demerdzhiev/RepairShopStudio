﻿using Microsoft.AspNetCore.Mvc;
using RepairShopStudio.Models;
using System.Diagnostics;
using static RepairShopStudio.Common.Constants.AdminConstants;

namespace RepairShopStudio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Check if the current user is in Admin role
        /// </summary>
        /// <returns>Redirects to Admin aerea</returns>
        public IActionResult ToAdminArea()
        {
            if (User.IsInRole(AdminRolleName))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}