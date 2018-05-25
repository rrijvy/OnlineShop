using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using ShopSystem.Data;

namespace ShopSystem.Controllers
{
    public class DeliveryDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeliveryDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeliveryDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DeliveryDetail.Include(d => d.Delivery).Include(d => d.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeliveryDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryDetail = await _context.DeliveryDetail
                .Include(d => d.Delivery)
                .Include(d => d.Product)
                .SingleOrDefaultAsync(m => m.DeliveryDetailId == id);
            if (deliveryDetail == null)
            {
                return NotFound();
            }

            return View(deliveryDetail);
        }

        // GET: DeliveryDetails/Create
        public IActionResult Create()
        {
            ViewData["DeliveryId"] = new SelectList(_context.Delivery, "DeliveryId", "DeliveryId");
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId");
            return View();
        }

        // POST: DeliveryDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeliveryDetailId,DeliveryId,ProductId,Quantity")] DeliveryDetail deliveryDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeliveryId"] = new SelectList(_context.Delivery, "DeliveryId", "DeliveryId", deliveryDetail.DeliveryId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", deliveryDetail.ProductId);
            return View(deliveryDetail);
        }

        // GET: DeliveryDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryDetail = await _context.DeliveryDetail.SingleOrDefaultAsync(m => m.DeliveryDetailId == id);
            if (deliveryDetail == null)
            {
                return NotFound();
            }
            ViewData["DeliveryId"] = new SelectList(_context.Delivery, "DeliveryId", "DeliveryId", deliveryDetail.DeliveryId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", deliveryDetail.ProductId);
            return View(deliveryDetail);
        }

        // POST: DeliveryDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeliveryDetailId,DeliveryId,ProductId,Quantity")] DeliveryDetail deliveryDetail)
        {
            if (id != deliveryDetail.DeliveryDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryDetailExists(deliveryDetail.DeliveryDetailId))
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
            ViewData["DeliveryId"] = new SelectList(_context.Delivery, "DeliveryId", "DeliveryId", deliveryDetail.DeliveryId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", deliveryDetail.ProductId);
            return View(deliveryDetail);
        }

        // GET: DeliveryDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryDetail = await _context.DeliveryDetail
                .Include(d => d.Delivery)
                .Include(d => d.Product)
                .SingleOrDefaultAsync(m => m.DeliveryDetailId == id);
            if (deliveryDetail == null)
            {
                return NotFound();
            }

            return View(deliveryDetail);
        }

        // POST: DeliveryDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryDetail = await _context.DeliveryDetail.SingleOrDefaultAsync(m => m.DeliveryDetailId == id);
            _context.DeliveryDetail.Remove(deliveryDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryDetailExists(int id)
        {
            return _context.DeliveryDetail.Any(e => e.DeliveryDetailId == id);
        }
    }
}
