using FrontToBack.DAL;
using FrontToBack.Extension;
using FrontToBack.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(Context context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Create() {

            List<SelectListItem> categories = (from i in _context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.Id.ToString()
                                               }).ToList();
            ViewBag.Category = categories;
            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product) {




            bool isExist = _context.Products.Any(p => p.Name.ToLower().Trim() == product.Name.ToLower().Trim());
            if (isExist)
            {
                ModelState.AddModelError("Name", "The product with this name already exists");
                View();
            }

            if (ModelState["ProductPhoto"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                ModelState.AddModelError("ProductPhoto", "Do not empty");
            }

            if (!product.ProductPhoto.IsImage())
            {
                ModelState.AddModelError("ProductPhoto", "only image");
                return View();
            }
            if (product.ProductPhoto.IsCorrectSize(300))
            {
                ModelState.AddModelError("ProductPhoto", "300den yuxari ola bilmez");
                return View();
            }



            string fileName = await product.ProductPhoto.SaveImageAsync(_env.WebRootPath, "img");

            Product newProduct = new Product
            {
                Category = product.Category,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = fileName,
                CategoryId = product.CategoryId

            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();

            return View(dbProduct);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath, "img", dbProduct.ImageUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.Products.Remove(dbProduct);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();
            List<SelectListItem> categories = (from i in _context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.Id.ToString()
                                               }).ToList();
            ViewBag.dgr = categories;
            return View(dbProduct);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product, int? id)
        {

            if (id == null) return NotFound();

            if (!ModelState.IsValid) return View();
            bool isExist = _context.Products.Any(c => c.Name.ToLower() == product.Name.ToLower().Trim());

            Product isExistProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);

            if (isExist && !(isExistProduct.Name.ToLower() == product.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "There is a product with this name");
                return View();
            };



            if (product.ProductPhoto != null)
            {
                if (ModelState["ProductPhoto"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    ModelState.AddModelError("ProductPhoto", "Do not empty");
                }

                if (!product.ProductPhoto.IsImage())
                {
                    ModelState.AddModelError("ProductPhoto", "only image");
                    return View();
                }
                if (product.ProductPhoto.IsCorrectSize(300))
                {
                    ModelState.AddModelError("ProductPhoto", "300den yuxari ola bilmez");
                    return View();
                }
                Product dbProduct = await _context.Products.FindAsync(id);
                string path = Path.Combine(_env.WebRootPath, "img", dbProduct.ImageUrl);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                string fileName = await product.ProductPhoto.SaveImageAsync(_env.WebRootPath, "img");

                dbProduct.Category = product.Category;
                dbProduct.Name = product.Name;
                dbProduct.Price = product.Price;
                dbProduct.ImageUrl = fileName;
                dbProduct.CategoryId = product.CategoryId;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}
