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
            _context.Currency_CreateOrUpdateOrDelete(currency);
        }

        public void Update(CurrencyDto currency)
        {
            _context.Currency_CreateOrUpdateOrDelete(currency);
        }

        public void Delete(CurrencyDto currency)
        {
            _context.Currency_CreateOrUpdateOrDelete(currency);
        }
    }
}
