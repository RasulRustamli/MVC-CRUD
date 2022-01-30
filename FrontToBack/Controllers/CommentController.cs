using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Context _context;

        public CommentController(Context context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async  Task<IActionResult> Index(int id)
        {
           

            Product product = _context.Products
                .Include(c => c.Comments)
                .ThenInclude(c=> c.User)
                .FirstOrDefault(p => p.Id == id);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.CurrentUserId = user.Id;

            return View(product);
        }

        public IActionResult Create(int? id)
        {
            Product product = _context.Products.Include(p => p.Comments).FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(string Text, int ProductId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Product product = await _context.Products.FindAsync(ProductId);

            Comment newComment = new Comment
            {
                Text = Text,
                ProductId = ProductId,
                AppUserId = user.Id
            };

            await _context.Comments.AddAsync(newComment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { Id = product.Id });
        }

        public async Task<IActionResult> Delete(int commentId)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == commentId);

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUser commentUser = await _userManager.FindByIdAsync(comment.AppUserId);

            if (user != commentUser) return NotFound();

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { Id = comment.ProductId });
        }

    }
}
