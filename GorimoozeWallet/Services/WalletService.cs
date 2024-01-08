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
            throw new NotImplementedException();
        }

        public WalletDto GetWalletByUserId(long userId)
        {
            throw new NotImplementedException();
        }

        public void Create(WalletDto wallet)
        {
            throw new NotImplementedException();
        }

        public void Update(WalletDto wallet)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PortfolioDto> GetPortfolioListByWallet(string guidWallet)
        {
            throw new NotImplementedException();
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
