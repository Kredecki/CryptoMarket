using CryptoMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoMarket.Data.Repositories
{
    public interface ISpotTradingRepository
    {
        Task<int> GetCurrencyId(string synbol);
        Task<decimal> GerAvailableBalance(Guid userId, int currency);
    }
    
    public class SpotTradingRepository : ISpotTradingRepository
    {
        private readonly CMDbContext db;

        public SpotTradingRepository(CMDbContext _db)
        {
            db = _db;
        }

        public async Task<int> GetCurrencyId(string symbol)
        {
            return await db.Currencies.Where(x => x.CurrencySymbol == symbol).Select(x => x.CurrencyId).FirstOrDefaultAsync();
        }

        public async Task<decimal> GerAvailableBalance(Guid userId, int currency)
        {
            return await db.UserAssets.Where(x => x.UserId == userId && x.CoinId == currency).Select(x => x.AvailableBalance).FirstOrDefaultAsync();
        }

    }
}
