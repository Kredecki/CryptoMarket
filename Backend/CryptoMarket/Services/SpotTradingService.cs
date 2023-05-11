using CryptoMarket.BindingModels;
using CryptoMarket.Data.Repositories;
using CryptoMarket.Models;
using Microsoft.VisualBasic;

namespace CryptoMarket.Services
{
    public interface ISpotTradingService
    {
        Task<decimal> GerAvailableBalance(Guid userId, string currency);
    }
    
    public class SpotTradingService : ISpotTradingService
    {
        private readonly ISpotTradingRepository spotTradingRepository;

        public SpotTradingService(ISpotTradingRepository _spotTradingRepository)
        {
            spotTradingRepository = _spotTradingRepository;
        }

        public async Task<decimal> GerAvailableBalance(Guid userId, string currency)
        {
            int currencyId = await spotTradingRepository.GetCurrencyId(currency);
            return await spotTradingRepository.GerAvailableBalance(userId, currencyId);
        }
    }
}
