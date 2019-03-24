using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppreciationApp.Models;
using AppreciationApp.Repository;
using AppreciationApp.ViewModels;

namespace AppreciationApp.Controllers
{
    public class AppreciationController : Controller
    {
        private readonly IFifteenFiveAppreciationRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppreciationController"/> class.
        /// </summary>
        public AppreciationController(IFifteenFiveAppreciationRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
          
            var highfives = repo.GetWeeklyHighFives();
            var AppreciationViewModel = new AppreciationViewModel()
            {
                Message = highfives.Last().Message,
                Username = highfives.Last().AppreciatorUser
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
