using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakDown_Assistance.Models;
using Microsoft.AspNetCore.Mvc;

namespace BreakDown_Assistance.Controllers
{
    public class MechanicsController : Controller
    {

        //public IMechanicsRepository _mechanicRepository;
        //public MechanicsController(IMechanicsRepository mechanicRepository)
        //{
        //    this._mechanicRepository = mechanicRepository;
        //}
        public ViewResult Index()
        {
            //var model = _mechanicRepository.GetAllMechanics();
            return View();
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}