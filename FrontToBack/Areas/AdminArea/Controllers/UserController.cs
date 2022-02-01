using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Areas.AdminArea.Controllers
{
   [Area("AdminArea")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Context _context;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager,Context context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }
        public IActionResult Index(string name)
        {

            var users = name == null ? _userManager.Users.ToList() : 
                 _userManager.Users.Where(u => u.FullName.ToLower().Contains(name.ToLower())).ToList();






            //var users = _userManager.Users.ToList();
            //List<UserReturnVM> userReturnVM = new List<UserReturnVM>();

            //foreach (var item in users)
            //{
            //    UserReturnVM userReturn = new UserReturnVM();
            //    userReturn.Id = item.Id;
            //    userReturn.FullName = item.FullName;
            //    userReturn.UserName = item.UserName;
            //    userReturn.Email = item.Email;
            //    //userReturn.Role = (await _userManager.GetRolesAsync(item))[0];
            //    userReturnVM.Add(userReturn);

            //}
            return View(users);
        }
        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            UserRoleVM userRoleVM = new UserRoleVM();
            userRoleVM.AppUser = user;
            userRoleVM.Roles = await _userManager.GetRolesAsync(user);

            return View(userRoleVM);
        }
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = new AppUser
            {
                FullName = registerVM.FullName,
                UserName = registerVM.UserName,
                Email = registerVM.Email

            };
            IdentityResult identity = await _userManager.CreateAsync(user, registerVM.Password);
            if (!identity.Succeeded)
            {
                foreach (var item in identity.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(user, "Member");
            await _signInManager.SignInAsync(user, true);

            return RedirectToAction("Index", "User");
        }

        public async Task<IActionResult> IsActive(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }
            if (appUser.IsActive) 
            {
                appUser.IsActive = false;

            }
            else
            {
                appUser.IsActive = true;
            }
            return RedirectToAction("Index");

        }

    }
}
