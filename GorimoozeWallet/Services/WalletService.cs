using GorimoozeWallet.Data;
using GorimoozeWallet.Dto;
using GorimoozeWallet.Interfaces;
using System.Text;
using GorimoozeWallet.Models;
using AutoMapper;

namespace GorimoozeWallet.Services
{
    public class WalletService : IWalletService
    {
        private readonly GorimoozeWalletDbContext _context;
        private readonly IMapper _mapper;

        public WalletService(GorimoozeWalletDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<Wallet> GetList()
        {
            return _context.Wallet.ToList();
        }

        public bool Exists(long walletId)
        {
            return _context.Wallet.Any(w => w.Id == walletId);
        }

        public WalletDto GetById(long walletId)
        {
            var wallet = _context.Wallet.Where(w => w.Id == walletId);
            var walletDto = _mapper.Map<WalletDto>(wallet);

            return walletDto;
        }

        public ICollection<Wallet> GetListByUserId(long userId)
        {
            return _context.Wallet.Where(w => w.Portfolio.UserId == userId).ToList();
        }

        public void Create(WalletDto walletDto)
        {
            _context.Wallet.Add(new Wallet()
            {
                WalletNumber = GenerateUniqueNumber(16),
                IsLocked = false,
                Score = 0.0,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                CurrencyId = walletDto.CurrencyId,
                PortfolioId = walletDto.PortfolioId,
                IsDeleted = false
            });
            _context.SaveChanges();
        }

        public void Update(long walletId, WalletDto walletDto)
        {
            _context.Wallet.Update(new Wallet()
            {
                Id = walletId,
                Score = walletDto.Score,
                UpdatedOn = DateTime.UtcNow
            });
            _context.SaveChanges();
        }

        public void Delete(long walletId)
        {
            var existingWallet = _context.Wallet.Find(walletId);
            if (existingWallet != null)
            {
                _context.Wallet.Update(new Wallet()
                {
                    UpdatedOn = DateTime.UtcNow,
                    IsDeleted = true,
                });
                _context.SaveChanges();
            }
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
