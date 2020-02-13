using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainsModel.Entities;
using DomainsModel.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly SignInManager<User> signInManager;
        public AccountController(UserManager<User> _userManager, RoleManager<Role> _roleManager, SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
        }
       public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(model.UserName);
                if (await userManager.IsInRoleAsync(user, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if(await userManager.IsInRoleAsync(user,"SuperAdmin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "SuperAdmin" });
                }
                
            }
            return View();
        }
        public IActionResult SignUp()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(User model)
        {
            var result = await userManager.CreateAsync(model, model.Password);
            if (result.Succeeded)
            {
                // var role = await roleManager.FindByNameAsync("User");
                var role = await roleManager.FindByNameAsync("SuperAdmin");
                if (role != null)
                {
                    var r = await userManager.AddToRoleAsync(model, role.Name);
                    if (r.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                }
            }
            return View();
        }
        public IActionResult SignOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult UnAuthorize()
        {
            return View();
        }
    }
}