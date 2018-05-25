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
    public class ProductImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductImages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductImage.Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productImage = await _context.ProductImage
                .Include(p => p.Product)
                .SingleOrDefaultAsync(m => m.ProductImageId == id);
            if (productImage == null)
            {
                return NotFound();
            }

            return View(productImage);
        }

        // GET: ProductImages/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Name");
            return View();
        }

        // POST: ProductImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductImageId,ProductId,ImageFileName")] ProductImage productImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", productImage.ProductId);
            return View(productImage);
        }

        // GET: ProductImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productImage = await _context.ProductImage.SingleOrDefaultAsync(m => m.ProductImageId == id);
            if (productImage == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", productImage.ProductId);
            return View(productImage);
        }

        // POST: ProductImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductImageId,ProductId,ImageFileName")] ProductImage productImage)
        {
            if (id != productImage.ProductImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductImageExists(productImage.ProductImageId))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", productImage.ProductId);
            return View(productImage);
        }

        // GET: ProductImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productImage = await _context.ProductImage
                .Include(p => p.Product)
                .SingleOrDefaultAsync(m => m.ProductImageId == id);
            if (productImage == null)
            {
                return NotFound();
            }

            return View(productImage);
        }

        // POST: ProductImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productImage = await _context.ProductImage.SingleOrDefaultAsync(m => m.ProductImageId == id);
            _context.ProductImage.Remove(productImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductImageExists(int id)
        {
            return _context.ProductImage.Any(e => e.ProductImageId == id);
        }
    }
}
