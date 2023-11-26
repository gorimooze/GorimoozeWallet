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

        public WalletDto GetWalletById(long id)
        {
            return _context.Wallet_GetById(id);
        }

        public WalletDto GetWalletByUserId(long userId)
        {
            throw new NotImplementedException();
        }

        public void Create(WalletDto wallet)
        {
            wallet.UniqueNumber = GenerateUniqueNumber(16);
            wallet.CreatedOn = DateTime.UtcNow;
            wallet.IsDeleted = false;

            _context.Wallet_CreateOrUpdate(wallet);
        }

        public void Update(WalletDto wallet)
        {
            _context.Wallet_CreateOrUpdate(wallet);
        }

        public void Delete(long id)
        {
            _context.Wallet_Delete(id);
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
