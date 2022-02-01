using FrontToBack.DAL;
using FrontToBack.Extension;
using FrontToBack.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SliderController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(Context context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            return View(sliders);
        }
        public IActionResult Create() {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {

            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                ModelState.AddModelError("Photo", "Do not Empty");

            }
            if (!slider.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Only Image");
                return View();
            }
            if (slider.Photo.IsCorrectSize(300))
            {
                ModelState.AddModelError("Photo", "300 den yuxari ola bilmez");
                return View();
            }

            Slider newSlider = new Slider();
            string fileName = await slider.Photo.SaveImageAsync(_env.WebRootPath, "img");
            newSlider.ImageUrl = fileName;
            await _context.Sliders.AddAsync(newSlider);
            await _context.SaveChangesAsync();
            //string root = _env.WebRootPath;
            //bool isImage = slider.Photo.ContentType.Contains("image/");


            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) return NotFound();
            Slider dbSlider = await _context.Sliders.FindAsync(id);
            if (dbSlider == null) return NotFound();

            return View(dbSlider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteSlider(int? id) {
            if (id == null) return NotFound();
            Slider dbSlider = await _context.Sliders.FindAsync(id);
            if (dbSlider == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath,"img",dbSlider.ImageUrl);
            if (System.IO.File.Exists(path)) {
                System.IO.File.Delete(path);
            }
            _context.Sliders.Remove(dbSlider);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Slider dbSlider = await _context.Sliders.FindAsync(id);
            if (dbSlider == null) return NotFound();

            return View(dbSlider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Slider slider, int? id)
        {

            if (id == null) return NotFound();
            if (slider.Photo != null)
            {

                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    ModelState.AddModelError("Photo", "Do not Empty");

                }
                if (!slider.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Only Image");
                    return View();
                }
                if (slider.Photo.IsCorrectSize(300))
                {
                    ModelState.AddModelError("Photo", "300 den yuxari ola bilmez");
                    return View();
                }

                Slider dbSlider = await _context.Sliders.FindAsync(id);
                string fileName = await slider.Photo.SaveImageAsync(_env.WebRootPath, "img");

                string path = Path.Combine(_env.WebRootPath, "img", dbSlider.ImageUrl);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                dbSlider.ImageUrl = fileName;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        
        
    }
}
