using GorimoozeWallet.Dto;

namespace GorimoozeWallet.Data
{
    public interface IGorimoozeWalletDbContext
    {
        ICollection<UserDto> User_GetAllUsers();
        //ICollection<CurrencyDto> Currency_GetAllCurrency();
        //CurrencyDto Currency_GetById(long id);
        //void Currency_CreateOrUpdateOrDelete(CurrencyDto currency);
        ICollection<WalletDto> Wallet_GetAll();
        void Wallet_CreateOrUpdateOrDelete(WalletDto wallet);
        WalletDto Wallet_GetByUserId(long userId);
        ICollection<PortfolioDto> Portfolio_GetGetPortfoliosByWallet(string guidWallet);
    }
}
