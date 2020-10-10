using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BreakDown_Assistance.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace BreakDown_Assistance.Controllers
{
    public class PurchaseProductsController : Controller
    {
        private readonly AppDbContext _context;

        public PurchaseProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseProducts
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PurchaseProduct.Include(p => p.products.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PurchaseProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseProduct = await _context.PurchaseProduct
                .Include(p => p.products)
                .FirstOrDefaultAsync(m => m.PurchaseProductID == id);
            if (purchaseProduct == null)
            {
                return NotFound();
            }

            return View(purchaseProduct);
        }

        // GET: PurchaseProducts/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductTitle");
            return View();
        }

        // POST: PurchaseProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseProductID,ProductID")] PurchaseProduct purchaseProduct)
        {
            if (ModelState.IsValid)
            {
                    _context.Add(purchaseProduct);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductTitle", purchaseProduct.ProductID);
            return View(purchaseProduct);
        }

        // GET: PurchaseProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseProduct = await _context.PurchaseProduct.FindAsync(id);
            if (purchaseProduct == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductTitle", purchaseProduct.ProductID);
            return View(purchaseProduct);
        }

        // POST: PurchaseProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseProductID,ProductID")] PurchaseProduct purchaseProduct)
        {
            if (id != purchaseProduct.PurchaseProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseProductExists(purchaseProduct.PurchaseProductID))
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
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductTitle", purchaseProduct.ProductID);
            return View(purchaseProduct);
        }

        // GET: PurchaseProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseProduct = await _context.PurchaseProduct
                .Include(p => p.products)
                .FirstOrDefaultAsync(m => m.PurchaseProductID == id);
            if (purchaseProduct == null)
            {
                return NotFound();
            }

            return View(purchaseProduct);
        }

        // POST: PurchaseProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseProduct = await _context.PurchaseProduct.FindAsync(id);
            _context.PurchaseProduct.Remove(purchaseProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseProductExists(int id)
        {
            return _context.PurchaseProduct.Any(e => e.PurchaseProductID == id);
        }
    }
}
