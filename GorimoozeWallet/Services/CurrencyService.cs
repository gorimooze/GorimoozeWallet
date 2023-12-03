using GorimoozeWallet.Data;
using GorimoozeWallet.Dto;
using GorimoozeWallet.Interfaces;

namespace GorimoozeWallet.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IGorimoozeWalletDbContext _context;

        public CurrencyService(IGorimoozeWalletDbContext context)
        {
            _context = context;
        }

        public ICollection<CurrencyDto> GetCurrencyList()
        {
            return _context.Currency_GetAllCurrency();
        }

        public CurrencyDto GetCurrencyById(long id)
        {
            return _context.Currency_GetById(id);
        }

        public void Create(CurrencyDto currency)
        {
            currency.IsDeleted = false;
            _context.Currency_CreateOrUpdateOrDelete(currency);
        }

        public void Update(CurrencyDto currency)
        {
            _context.Currency_CreateOrUpdateOrDelete(new CurrencyDto()
            {
                Id = currency.Id,
                Name = currency.Name,
                ShortName = currency.ShortName,
                StateActivity = currency.StateActivity,
                IsActive = currency.IsActive,
                ImageName = currency.ImageName,
                ImageData = currency.ImageData
            });
        }

        public void Delete(long currencyId)
        {
            _context.Currency_CreateOrUpdateOrDelete(new CurrencyDto()
            {
                Id = currencyId,
                IsDeleted = true
            });
        }
    }
}
