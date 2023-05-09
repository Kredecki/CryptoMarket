using CryptoMarket.BindingModels;
using CryptoMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoMarket.Data.Repositories
{
    public interface IAccountRepository
    {
        IQueryable<Guid> GetUserIdByEmailAsync(string email);
        Task<List<Currency>> GetCurrenciesAsync();
        Task CreateAssets(UserAsset userAsset);
    }

    public class AccountRepository : IAccountRepository
    {
        private readonly CMDbContext db;

        public AccountRepository(CMDbContext _db)
        {
            db = _db;
        }

        public IQueryable<Guid> GetUserIdByEmailAsync(string email)
        {
            return db.Users.Where(x => x.Email == email).Select(x => x.Id);
        }

        public async Task<List<Currency>> GetCurrenciesAsync()
        {
            return await db.Currencies.ToListAsync();
        }

        public async Task CreateAssets(UserAsset userAsset)
        {
            await db.UserAssets.AddAsync(userAsset);
            await db.SaveChangesAsync();
        }
    }
}
