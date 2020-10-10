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
    public class PurchaseDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public PurchaseDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseDetails
        public async Task<IActionResult> Save()
        {
            if (Program._purchase == null)
                return this.RedirectToAction("Purchases", "Index");
            var purchaseDb = await this._context.Purchases.FindAsync(Program._purchase.PurchaseID);
            var context = this._context.PurchaseDetails.Include(c => c.purchaseProduct).Where(c => c.PurchaseID == purchaseDb.PurchaseID);
            List<PurchaseDetail> list = new List<PurchaseDetail>();
            list = context.ToList();
            int totalPrice = 0;
            foreach (PurchaseDetail purchaseDetail in list)
                totalPrice += purchaseDetail.Price;
            purchaseDb.totalPrice = totalPrice;
            purchaseDb.Date = DateTime.Now;
            this._context.Update(purchaseDb);
            await this._context.SaveChangesAsync();
            return this.RedirectToAction("Index", "Purchases");
        }
        // GET: PurchaseDetails
        public async Task<IActionResult> Index(int? purchaseID)
        {
            if (purchaseID == null)
            {
                var shopContexts = this._context.PurchaseDetails.Include(p => p.purchase).Include(p => p.purchaseProduct);
                return this.View(await shopContexts.ToListAsync());
            }
            Purchase purchase = await this._context.Purchases.FindAsync(purchaseID);
            Program._purchase = purchase;
            var shopContext = this._context.PurchaseDetails.Include(p => p.purchase).Include(p => p.purchaseProduct.products).Where(c => c.PurchaseID == Program._purchase.PurchaseID);
            return this.View(await shopContext.ToListAsync());
        }

        // GET: PurchaseDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _context.PurchaseDetails
                .Include(p => p.purchase)
                .Include(p => p.purchaseProduct.products)
                .FirstOrDefaultAsync(m => m.PurchaseDetailID == id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return View(purchaseDetail);
        }

        // GET: PurchaseDetails/Create
        public IActionResult Create()
        {
            var PurchaseDB = this._context.Purchases.Where(c => c.PurchaseID == Program._purchase.PurchaseID);
            var product = this._context.PurchaseProduct.Include(c => c.products);
            ViewData["PurchaseID"] = new SelectList(PurchaseDB.ToList(), "PurchaseID", "PurchaseTitle");
            ViewData["PurchaseProductID"] = new SelectList(product.ToList(), "PurchaseProductID", "products.ProductTitle", _context.PurchaseProduct.Include(c => c.products.ProductTitle));
            return View();
        }

        // POST: PurchaseDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseDetailID,PurchaseProductID,PurchaseID,Quantity,Price,Date")] PurchaseDetail purchaseDetail)
        {
            if (ModelState.IsValid)
            {
                var purchaseproduct = await this._context.PurchaseProduct.Include(c => c.products).FirstOrDefaultAsync(c => c.PurchaseProductID == purchaseDetail.PurchaseProductID);
                purchaseDetail.Price = purchaseproduct.products.Price * purchaseDetail.Quantity;
                purchaseDetail.Date = DateTime.Now;
                this._context.Add(purchaseDetail);
                await this._context.SaveChangesAsync();
                return this.RedirectToAction("Index", new { purchaseID = Program._purchase.PurchaseID });
            }
            var PurchaseDB = this._context.Purchases.Where(c => c.PurchaseID == Program._purchase.PurchaseID);
            var product = this._context.PurchaseProduct.Include(c => c.products);
            ViewData["PurchaseID"] = new SelectList(PurchaseDB.ToList(), "PurchaseID", "PurchaseTitle");
            ViewData["PurchaseProductID"] = new SelectList(product.ToList(), "PurchaseProductID", "products.ProductTitle", _context.PurchaseProduct.Include(c => c.products.ProductTitle));
            return this.View(purchaseDetail);
        }
        // GET: PurchaseDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _context.PurchaseDetails.FindAsync(id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }
            var PurchaseDB = this._context.Purchases.Where(c => c.PurchaseID == Program._purchase.PurchaseID);
            var product = this._context.PurchaseProduct.Include(c => c.products);
            ViewData["PurchaseID"] = new SelectList(PurchaseDB.ToList(), "PurchaseID", "PurchaseTitle");
            ViewData["PurchaseProductID"] = new SelectList(product.ToList(), "PurchaseProductID", "products.ProductTitle", _context.PurchaseProduct.Include(c => c.products.ProductTitle));
            return View(purchaseDetail);
        }

        // POST: PurchaseDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseDetailID,PurchaseProductID,PurchaseID,Quantity,Price,Date")] PurchaseDetail purchaseDetail)
        {
            if (id != purchaseDetail.PurchaseDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var purchaseproduct = await this._context.PurchaseProduct.Include(c => c.products).FirstOrDefaultAsync(c => c.PurchaseProductID == purchaseDetail.PurchaseProductID);
                    purchaseDetail.Price = purchaseproduct.products.Price * purchaseDetail.Quantity;
                    purchaseDetail.Date = DateTime.Now;
                    this._context.Update(purchaseDetail);
                    await this._context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseDetailExists(purchaseDetail.PurchaseDetailID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectToAction("Index", new { purchaseID = Program._purchase.PurchaseID });
            }
            var product = this._context.PurchaseProduct.Include(c => c.products);

            var PurchaseDB = this._context.Purchases.Where(c => c.PurchaseID == Program._purchase.PurchaseID);
            ViewData["PurchaseProductID"] = new SelectList(product.ToList(), "PurchaseProductID", "products.ProductTitle", _context.PurchaseProduct.Include(c => c.products.ProductTitle));
            return View(purchaseDetail);
        }

        // GET: PurchaseDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetail = await _context.PurchaseDetails
                .Include(p => p.purchase)
                .Include(p => p.purchaseProduct.products)
                .FirstOrDefaultAsync(m => m.PurchaseDetailID == id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return View(purchaseDetail);
        }

        // POST: PurchaseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseDetail = await _context.PurchaseDetails.FindAsync(id);
            _context.PurchaseDetails.Remove(purchaseDetail);
            await _context.SaveChangesAsync();
            return this.RedirectToAction("Index", new { purchaseID = Program._purchase.PurchaseID });
        }

        private bool PurchaseDetailExists(int id)
        {
            return _context.PurchaseDetails.Any(e => e.PurchaseDetailID == id);
        }
    }
}
