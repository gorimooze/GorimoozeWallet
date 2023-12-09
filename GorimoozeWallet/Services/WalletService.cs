using GorimoozeWallet.Data;
using GorimoozeWallet.Dto;
using GorimoozeWallet.Interfaces;
using System.Text;

namespace GorimoozeWallet.Services
{
    public class WalletService : IWalletService
    {
        private readonly IGorimoozeWalletDbContext _context;

        public WalletService(IGorimoozeWalletDbContext context)
        {
            _context = context;
        }


        public ICollection<WalletDto> GetWalletList()
        {
            return _context.Wallet_GetAll();
        }

        public WalletDto GetWalletByUserId(long userId)
        {
            return _context.Wallet_GetByUserId(userId);
        }

        public void Create(WalletDto wallet)
        {
            wallet.CreatedOn = DateTime.UtcNow;
            wallet.IsDeleted = false;

            _context.Wallet_CreateOrUpdateOrDelete(wallet);
        }

        public void Update(WalletDto wallet)
        {
            _context.Wallet_CreateOrUpdateOrDelete(wallet);
        }

        public void Delete(long id)
        {
            _context.Wallet_CreateOrUpdateOrDelete(new WalletDto()
            {
                Id = id,
                IsDeleted = true
            });
        }

        public ICollection<PortfolioDto> GetPortfolioListByWallet(string guidWallet)
        {
            return _context.Portfolio_GetGetPortfoliosByWallet(guidWallet);
        }

        public void CreatePortfolio(PortfolioDto portfolio)
        {
            throw new NotImplementedException();
        }

        public void UpdatePortfolio(PortfolioDto portfolio)
        {
            throw new NotImplementedException();
        }

        public void DeletePortfolio(long id)
        {
            throw new NotImplementedException();
        }

        private string GenerateUniqueNumber(int length)
        {
            const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder result = new StringBuilder();

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(characters.Length);
                result.Append(characters[index]);
            }

            return result.ToString();
        }
    }
}
