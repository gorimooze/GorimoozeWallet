using AutoMapper;
using GorimoozeWallet.Data;
using GorimoozeWallet.Dto;
using GorimoozeWallet.Interfaces;
using GorimoozeWallet.Models;

namespace GorimoozeWallet.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly GorimoozeWalletDbContext _context;
        private readonly IMapper _mapper;

        public PortfolioService(GorimoozeWalletDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<Portfolio> GetList()
        {
            throw new NotImplementedException();
        }

        public bool Exists(long portfolioId)
        {
            throw new NotImplementedException();
        }

        public PortfolioDto GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Create(PortfolioDto portfolioDto)
        {

            var portfolio = new Portfolio()
            {
                IsLocked = false,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsDeleted = false,
                UserId = portfolioDto.UserId,
            };

            _context.Add(portfolio);
            _context.SaveChanges();
        }

        public void Update(long portfolioId, PortfolioDto portfolioDto)
        {
            throw new NotImplementedException();
        }

        public void Delete(long portfolioId)
        {
            throw new NotImplementedException();
        }
    }
}
