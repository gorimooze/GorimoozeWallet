using GorimoozeWallet.Dto;

namespace GorimoozeWallet.Interfaces
{
    public interface ICurrencyService
    {
        ICollection<CurrencyDto> GetCurrencyList();
        CurrencyDto GetCurrencyById(long id);
        void Create(CurrencyDto currency);
        void Update(CurrencyDto currency);
        void Delete(long currencyId);
    }
}
