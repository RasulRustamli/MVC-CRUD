using FrontToBack.DAL;
using FrontToBack.HomeModels;
using FrontToBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(Context context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        public async  Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.UserName = user.FullName;
            };
            List<Slider> sliders = _context.Sliders.ToList();
            SliderDesc slider = _context.SliderDescs.FirstOrDefault();
            List<Category> categories = _context.Categories.ToList();
            List<Product> products = _context.Products.ToList();
            About_Video about_Videos = _context.About_Videos.FirstOrDefault();
            HomeVm homeVm = new HomeVm();
            homeVm.Products = products;
            homeVm.Sliders = sliders;
            homeVm.SliderDesc = slider;
            homeVm.Categories = categories;
            homeVm.About_Videos = about_Videos;
            return View(homeVm);
        }
    }
}
