using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly Context _context;

        public FooterViewComponent(Context context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            Footer footer = _context.Footers.FirstOrDefault();

            return View(await Task.FromResult(footer));
        }

    }
}
