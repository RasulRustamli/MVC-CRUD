using FrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.HomeModels
{
    public class HomeVm
    {
        public List<Slider> Sliders { get; set; }
        public List<Product> Products { get; set; }
        public SliderDesc SliderDesc { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public About_Video About_Videos { get; set; }
    }
}
