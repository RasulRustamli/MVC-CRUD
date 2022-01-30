using FrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.ViewModels
{
    public class CommentProductVM
    {
        public int ProductId { get; set; }
        public string  Text { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
