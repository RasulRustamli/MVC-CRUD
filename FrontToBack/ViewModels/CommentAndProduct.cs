using FrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.ViewModels
{
    public class CommentAndProduct
    {
        public Product product { get; set; }
        public List<Comment> comment { get; set; }
    }
}
