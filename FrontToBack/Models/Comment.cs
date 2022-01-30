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
        [Required, MaxLength(300)]
        public string Text { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string AppUserId { get; set; }
        public AppUser User { get; set; }
    }
}
