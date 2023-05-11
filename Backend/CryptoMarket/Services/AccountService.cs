using CryptoMarket.BindingModels;
using CryptoMarket.Data.Repositories;
using CryptoMarket.Models;
using Microsoft.VisualBasic;

namespace CryptoMarket.Services
{
    public interface IAccountService
    {
        IQueryable<Guid> GetUserIdByEmailAsync(string email);
        Task<List<Currency>> GetCurrenciesAsync();
        Task CreateAssets(Guid userId, List<Currency> currencyList);
    }

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository _accountRepository)
        {
            accountRepository = _accountRepository;
        }

        public IQueryable<Guid> GetUserIdByEmailAsync(string email)
        {
            return accountRepository.GetUserIdByEmailAsync(email);
        }

        public async Task<List<Currency>> GetCurrenciesAsync()
        {
            return await accountRepository.GetCurrenciesAsync();
        }

        public async Task CreateAssets(Guid userId, List<Currency> currencyList)
        {
            User user = new User();
            user.Id = userId;

            foreach (var currency in currencyList)
            {
                UserAsset userAsset = new UserAsset();
                userAsset.AssetId = Guid.NewGuid();
                userAsset.UserId = user.Id;
                userAsset.CoinId = currency.CurrencyId;
                userAsset.AvailableBalance = 0;
                userAsset.CreatedTime = DateAndTime.Now;
                userAsset.ModifyTime = DateAndTime.Now;
                await accountRepository.CreateAssets(userAsset);
            }
        }
    }
}
