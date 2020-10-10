using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BreakDown_Assistance.Models;
using Microsoft.EntityFrameworkCore;

namespace BreakDown_Assistance.Controllers
{
    public class LoginController : Controller
    {
        AppDbContext _context;
        public LoginController(AppDbContext shopContext)
        {
            _context = shopContext;
        }
        public async Task<IActionResult> Login(string text)
        {
            ViewData["text"] = text;
            return this.View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("AdminID,Name,Email,Password")] Admin admin)
        {
            var LoginDB = this._context.Admins;
            if (LoginDB == null)
            {
                return this.RedirectToAction("Login", new { text = "Invalid! Password or email" });

            }

            List<Admin> List = LoginDB.ToList();
            foreach (Admin login in List)
            {
                if (login.Email == admin.Email && login.Password == admin.Password)
                {
                    Program._admin = login;
                    break;
                }
            }
            if (Program._admin.Password == null && Program._admin.Email == null)
                return this.RedirectToAction("Login", new { text = "Invalid! Password or email" });
            return this.RedirectToAction(nameof(Profile));
        }
        public async Task<IActionResult> Profile()
        {
            return this.View(await this._context.Admins.ToListAsync());
        }
    }
}