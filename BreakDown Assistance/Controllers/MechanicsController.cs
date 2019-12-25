using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BreakDown_Assistance.Models;

namespace BreakDown_Assistance.Controllers
{
    public class MechanicsController : Controller
    {
        private readonly AppDbContext _context;

        public MechanicsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Mechanics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mechanics.ToListAsync());
        }

        // GET: Mechanics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanics = await _context.Mechanics
                .FirstOrDefaultAsync(m => m.id == id);
            if (mechanics == null)
            {
                return NotFound();
            }

            return View(mechanics);
        }

        // GET: Mechanics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mechanics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,contact_Number,availability,longitude,latitude")] Mechanics mechanics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mechanics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mechanics);
        }

        // GET: Mechanics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanics = await _context.Mechanics.FindAsync(id);
            if (mechanics == null)
            {
                return NotFound();
            }
            return View(mechanics);
        }

        // POST: Mechanics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,contact_Number,availability,longitude,latitude")] Mechanics mechanics)
        {
            if (id != mechanics.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mechanics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MechanicsExists(mechanics.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mechanics);
        }

        // GET: Mechanics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanics = await _context.Mechanics
                .FirstOrDefaultAsync(m => m.id == id);
            if (mechanics == null)
            {
                return NotFound();
            }

            return View(mechanics);
        }

        // POST: Mechanics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mechanics = await _context.Mechanics.FindAsync(id);
            _context.Mechanics.Remove(mechanics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MechanicsExists(int id)
        {
            return _context.Mechanics.Any(e => e.id == id);
        }
    }
}
