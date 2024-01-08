using GorimoozeWallet.Dto;
using GorimoozeWallet.Models;

namespace GorimoozeWallet.Interfaces
{
    public interface IPortfolioService
    {
        ICollection<Portfolio> GetList();
        bool Exists(long portfolioId);
        PortfolioDto GetById(long id);
        void Create(PortfolioDto portfolioDto);
        void Update(long portfolioId, PortfolioDto portfolioDto);
        void Delete(long portfolioId);
    }
}
