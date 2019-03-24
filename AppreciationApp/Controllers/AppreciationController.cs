using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppreciationApp.Models;
using AppreciationApp.ViewModels;

namespace AppreciationApp.Controllers
{
    public class AppreciationController : Controller
    {
        public IActionResult Index()
        {
            var AppreciationViewModel = new AppreciationViewModel()
            {
                Message = "Alan How, Keep it the good work on this appreciation app!",
                Username = "Joshua Duxbury"
            };

            return View(AppreciationViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
