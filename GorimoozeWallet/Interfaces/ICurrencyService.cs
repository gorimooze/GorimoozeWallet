using GorimoozeWallet.Dto;
using GorimoozeWallet.Models;

namespace GorimoozeWallet.Interfaces
{
    public interface ICurrencyService
    {
        ICollection<Currency> GetCurrencyList();
        bool CurrencyExists(long currencyId);
        CurrencyDto GetCurrencyById(long id);
        void Create(CurrencyDto currencyDto);
        void Update(long currencyId, CurrencyDto currencyDto);
        void Delete(long currencyId);
    }
}
