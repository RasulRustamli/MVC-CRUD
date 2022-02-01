using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string userName { get; set; }
    }
}
