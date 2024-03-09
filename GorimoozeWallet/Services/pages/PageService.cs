using GorimoozeWallet.Data;
using GorimoozeWallet.Dto.pages;
using GorimoozeWallet.Interfaces.pages;
using GorimoozeWallet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GorimoozeWallet.Services.pages
{
    public class PageService : IPageService
    {
        private readonly GorimoozeWalletDbContext _context;

        public PageService(GorimoozeWalletDbContext context)
        {
            _context = context;
        }

        public IList<ProfileDto> Profile_GetByUserId(long userId)
        {
            var list = _context.Portfolio
                .Where(p => p.UserId == userId && !p.IsDeleted)
                .SelectMany(
                    p => p.Wallets.DefaultIfEmpty(), // Использование DefaultIfEmpty создает LEFT JOIN
                    (portfolio, wallet) => new { portfolio, wallet })
                .Select(x => new ProfileDto
                {
                    PortfolioName = x.portfolio.Name,
                    WalletId = x.wallet != null ? x.wallet.Id : (long?)null, // Учитывайте, что кошелек может быть null
                    Score = x.wallet != null ? x.wallet.Score : (double?)null,
                    CurrencyName = x.wallet != null ? x.wallet.Currency.Name : null,
                    PortfolioId = x.portfolio.Id
                })
                .ToList();

            return list;
        }
    }
}
