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
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult>  Create(string role) 
        {
            if (!string.IsNullOrEmpty(role))
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public async Task<IActionResult> DeleteRole(string Id)
        {
            var roleD = await _roleManager.FindByIdAsync(Id);
            await _roleManager.DeleteAsync(roleD);

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            UpdateRoleVM updateRoleVM = new UpdateRoleVM
            {
                User = user,
                UserId = user.Id,
                Roles = _roleManager.Roles.ToList(),
                UserRoles = await _userManager.GetRolesAsync(user),


            };
            return View(updateRoleVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(string id,List<string>roles)
        {
            var user = await _userManager.FindByIdAsync(id);
            var dbroles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            var addedRole1 = roles.Except(userRoles);
            var removedRole = userRoles.Except(roles);
            await _userManager.AddToRolesAsync(user, addedRole1);
            await _userManager.RemoveFromRolesAsync(user, removedRole);
            return RedirectToAction("Index");
        }
    }
}
