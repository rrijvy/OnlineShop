using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using ShopSystem.Data;

namespace ShopSystem.Controllers
{
    public class GetDataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GetDataController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryProducts(int id)
        {
            //var CategoryProducts = _context.Product.Include(y => y.ProductImage).Where(x => x.CategoryId == id).ToList();

            var CategoryProducts = _context.Product.
                Join(_context.ProductImage,
                x => x.ProductId,
                y => y.ProductId,
                (x, y) => new
                {
                    x.ProductId,
                    x.Name,
                    x.Price,
                    x.UOM,
                    x.CategoryId,
                    y.ImageFileName
                }).Where(c => c.CategoryId == id);

            //var CategoryProducts = from prod in _context.Product
            //                       join iprod in _context.ProductImage on prod.ProductId equals iprod.ProductId
            //                       where prod.CategoryId == id
            //                       select new
            //                       {
            //                           productId = prod.ProductId,
            //                           name = prod.Name,
            //                           price = prod.Price,
            //                           uom = prod.UOM,
            //                           categoryId = prod.CategoryId,
            //                           imageFileName = iprod.ImageFileName
            //                       };



            //ViewBag.ProductImage = _context.Product.Include(x => x.ProductImage).AsNoTracking();

            return Json(CategoryProducts.ToList());
        }

        public IActionResult ImagesOfProduct(int id)
        {
            var ImagesOfProduct = _context.ProductImage.Where(x => x.ProductId == id);
            return Json(ImagesOfProduct.ToList());
        }

        public IActionResult ViewCart(List<string> values)
        {
            return Json(values);
        }

        

        
    }
}