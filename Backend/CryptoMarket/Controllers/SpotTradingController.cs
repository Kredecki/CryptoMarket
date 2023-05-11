using CryptoMarket.BindingModels;
using CryptoMarket.Models;
using CryptoMarket.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CryptoMarket.Controllers
{
    public class SpotTradingController : Controller
    {
        private UserManager<User> userManager;

        private readonly ISpotTradingService spotTradingService;

        public SpotTradingController(UserManager<User> _userManager, ISpotTradingService _spotTradingService)
        {
            userManager = _userManager;
            spotTradingService = _spotTradingService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<decimal> GetAvailableBalance(string currency)
        {
            Guid userId = Guid.Parse("93D74B90-86CF-471B-E579-08DB50E65143");

            decimal availableBalance = await spotTradingService.GerAvailableBalance(userId, "USDT");

            return availableBalance;
        }
    }
}
