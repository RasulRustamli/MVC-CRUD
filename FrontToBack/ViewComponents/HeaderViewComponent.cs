using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly Context _context;

        public HeaderViewComponent(Context context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult>  InvokeAsync() {

            ViewBag.ProductCount = 0;
            if (Request.Cookies["basket"]!=null)
            {
                
                List<BasketProduct> products = JsonConvert.DeserializeObject<List<BasketProduct>>(Request.Cookies["basket"]);
                ViewBag.ProductCount = products.Count;
                //foreach (var item in products)
                //{
                //    total += item.Count;
                //}
                ViewBag.ProductCount = products.Count;
            }
            Bio bio = _context.Bios.FirstOrDefault();

            return View(await Task.FromResult(bio));
        }
    }
}
