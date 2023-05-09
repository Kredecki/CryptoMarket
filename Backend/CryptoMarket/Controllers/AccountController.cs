using AutoMapper;
using CryptoMarket.BindingModels;
using CryptoMarket.Migrations;
using CryptoMarket.Models;
using CryptoMarket.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CryptoMarket.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole<Guid>> roleManager;
        private SignInManager<User> signInManager;
        private readonly IMapper mapper;

        private readonly IAccountService accountService;

        public AccountController(UserManager<User> _userManager, RoleManager<IdentityRole<Guid>> _roleManager, SignInManager<User> _signInManager, IMapper _mapper, IAccountService _accountService)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
            mapper = _mapper;

            accountService = _accountService;
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
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new User { UserName = userModel.Email, Email = userModel.Email };
                    var result = await userManager.CreateAsync(user, userModel.Password);
                    if (result.Succeeded)
                    {
                        var userIds = accountService.GetUserIdByEmailAsync(userModel.Email);
                        Guid userId = await userIds.FirstOrDefaultAsync();
                        var currencyList = await accountService.GetCurrenciesAsync();
                        await accountService.CreateAssets(userId, currencyList);

                        return Ok(new { message = "Registration successful" });
                    }
                }
            }catch(Exception ex) { }

            return BadRequest();
        }
    }
}
