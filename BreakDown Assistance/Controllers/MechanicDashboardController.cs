using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakDown_Assistance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BreakDown_Assistance.Controllers
{
    public class MechanicDashboardController : Controller
    {
        private readonly AppDbContext _context;

        public MechanicDashboardController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            var dBContext = _context.Requests.Include(r => r.mehanics).Where(r => r.mechanic_ID == 1);
            return View(await dBContext.ToListAsync());
        }
    }
}