using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Controllers
{
    public class ProductListController : Controller
    {
        private readonly Context _context;

        public ProductListController(Context context)
        {
            _context = context;
        }
        public IActionResult  Index(int id)
        {
            //var product = _context.Products.Find(id1);
            //List<Comment> comments = _context.comments.ToList();
            //CommentAndProduct commentAndProduct = new CommentAndProduct();



            //IEnumerable<Comment> comments = _context.comments.Where(c => c.ProductId == id);

            //Product products = _context.Products.Include(c => c.commentList).FirstOrDefault(f=>f.Id == id);

            //Product product1 = new Product
            //{
            //    ImageUrl = products.ImageUrl,
            //    commentList = products.commentList,
            //};
            //return View(product1);
            return View();

        }
        public IActionResult Delete(int id) {

            var findId = _context.comments.Find(id);
            _context.comments.Remove(findId);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Comment c)
        {
           
            _context.comments.Add(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }

        public IActionResult Update(int Id)
        {
            var departGetir = _context.comments.Find(Id);
            return View(departGetir);

        }
        [HttpPost]
        [ActionName("Update")]
        public IActionResult UpdateComment(int id, Comment c)
        {
            var findId = _context.comments.Find(id);
            findId.Text = c.Text;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
