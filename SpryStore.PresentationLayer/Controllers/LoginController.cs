﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpryStore.EntityLayer.Concrete;
using SpryStore.PresentationLayer.Models;
using System.Threading.Tasks;

namespace SpryStore.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View();
            }
        }
    }
}
