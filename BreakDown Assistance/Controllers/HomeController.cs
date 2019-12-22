using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BreakDown_Assistance.Models;

namespace BreakDown_Assistance.Controllers
{
    public class HomeController : Controller
    {

        public readonly IMechanicsRepository _mechanicRepository;
        public HomeController(IMechanicsRepository mechanicRepository)
        {
            this._mechanicRepository = mechanicRepository;
        }
        public ViewResult Index()
        {
            var model = _mechanicRepository.GetAllMechanics();
            return View(model);
        }



        //private readonly ILogger<HomeController> _logger;


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}


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
