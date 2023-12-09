using GorimoozeWallet.Dto;

namespace GorimoozeWallet.Interfaces
{
    public interface IWalletService
    {
        ICollection<WalletDto> GetWalletList();
        WalletDto GetWalletByUserId(long userId);
        void Create(WalletDto wallet);
        void Update(WalletDto wallet);
        void Delete(long id);
        ICollection<PortfolioDto> GetPortfolioListByWallet(string guidWallet);
        void CreatePortfolio(PortfolioDto portfolio);
        void UpdatePortfolio(PortfolioDto portfolio);
        void DeletePortfolio(long id);
    }
}
