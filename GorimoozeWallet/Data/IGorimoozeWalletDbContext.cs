using GorimoozeWallet.Dto;
using GorimoozeWallet.Models;

namespace GorimoozeWallet.Data
{
    public interface IGorimoozeWalletDbContext
    {
        ICollection<UserDto> User_GetAllUsers();
        ICollection<CurrencyDto> Currency_GetAllCurrency();
        CurrencyDto Currency_GetById(long id);
        void Currency_CreateOrUpdateOrDelete(CurrencyDto currency);
    }
}
