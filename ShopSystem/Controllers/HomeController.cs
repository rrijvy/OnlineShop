using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopSystem.Data;
using ShopSystem.Models;

namespace ShopSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.categories = _context.Category;
            return View();
        }

        public IActionResult Search(string searchText)
        {
            /*
            var searchItem = from item in _context.Product
                             join itemImage in _context.ProductImage on item.ProductId equals itemImage.ProductId
                             where item.Name.Contains(searchText)
                             select new
                             {
                                 productId = item.ProductId,
                                 name = item.Name,
                                 price = item.Price,
                                 uom = item.UOM,
                                 categoryId = item.CategoryId,
                                 imageFileName = itemImage.ImageFileName
                             };
             */

            var searchItem = _context.Product.
                Join(_context.ProductImage,
                x => x.ProductId,
                y => y.ProductId,
                (x, y) => new ProductsWithImage
                {
                    ProductId =  x.ProductId,
                    Name = x.Name,
                    Price = x.Price,
                    UOM = x.UOM,
                    CategoryId = x.CategoryId,
                    ImageFileName = y.ImageFileName
                }).Where(c => c.Name.Contains(searchText));

            ViewBag.searchItems = searchItem;
            return View();

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class ProductsWithImage
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string UOM { get; set; }
        public int CategoryId { get; set; }
        public string ImageFileName { get; set; }
    }
}
