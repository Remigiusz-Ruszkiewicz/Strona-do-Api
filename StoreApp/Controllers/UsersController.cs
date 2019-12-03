using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using StoreApp.Services;

namespace StoreApp.Controllers
{
    public class UsersController : Controller
    {
        public UsersController(IUserService userService)
        {
            this.UserService = userService;
        }

        public IUserService UserService { get; }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            var token = await UserService.LoginAsync(user);
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction(nameof(Login));
            }
            Response.Cookies.Append("Token", token);
            return RedirectToAction("Index", "Products");
            
        }
    }
}