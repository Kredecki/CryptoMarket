﻿using AutoMapper;
using CryptoMarket.BindingModels;
using CryptoMarket.Migrations;
using CryptoMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CryptoMarket.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole<Guid>> roleManager;
        private SignInManager<User> signInManager;
        private readonly IMapper mapper;

        public AccountController(UserManager<User> _userManager, RoleManager<IdentityRole<Guid>> _roleManager, SignInManager<User> _signInManager, IMapper _mapper)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromForm]UserLogin model)
        {
            User user;
            Microsoft.AspNetCore.Identity.SignInResult result;

            if (ModelState.IsValid && (user = await userManager.FindByEmailAsync(model.Username)) != null
                && (await signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
            {
                return Ok(new { message = "Login successful" });
            }
            return BadRequest(new { message = "Invalid username or password" });
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok(new { message = "Logout successful" });
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromForm]UserRegistration userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = userModel.Email, Email = userModel.Email };
                var result = await userManager.CreateAsync(user, userModel.Password);
                if (result.Succeeded)
                {
                    return Ok(new { message = "Registration successful" });
                }
            }
            return BadRequest();
        }

    }
}
