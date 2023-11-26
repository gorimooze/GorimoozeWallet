using GorimoozeWallet.Dto;

namespace GorimoozeWallet.Data
{
    public interface IGorimoozeWalletDbContext
    {
        ICollection<UserDto> User_GetAllUsers();
        ICollection<CurrencyDto> Currency_GetAllCurrency();
        CurrencyDto Currency_GetById(long id);
        void Currency_CreateOrUpdateOrDelete(CurrencyDto currency);
        ICollection<WalletDto> Wallet_GetAll();
        WalletDto Wallet_GetById(long id);
        void Wallet_CreateOrUpdate(WalletDto wallet);
        void Wallet_Delete(long id);
    }
}
