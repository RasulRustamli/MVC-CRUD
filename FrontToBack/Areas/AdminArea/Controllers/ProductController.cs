using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly Context _context;
        public ProductController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products.Include(c => c.Category).ToList();
            return View(products);
        }

        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null) return NotFound();
            Product dbProduct = await _context.Products.FindAsync(Id);
            if (dbProduct == null) return NotFound();

            return View(dbProduct);
        }

        public IActionResult Create()
        {
            List<SelectListItem> categories = (from i in _context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.Id.ToString()
                                               }).ToList();
            ViewBag.dgr = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            bool isExist = _context.Products.Any(p => p.Name.ToLower().Trim() == product.Name.ToLower().Trim());
            if (isExist)
            {
                ModelState.AddModelError("Name", "The product with this name already exists");
                View();
            }
            Product newProduct = new Product
            {
                Category = product.Category,
                Name = product.Name,
                Price = product.Price,
                ProductImage =product.ProductImage,
                CategoryId = product.CategoryId

            };
            await _context.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}
