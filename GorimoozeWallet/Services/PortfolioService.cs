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
            return _context.Portfolio.ToList();
        }

        public ICollection<Portfolio> GetListByUserId(long userId)
        {
            return _context.Portfolio.Where(p => p.UserId == userId).ToList();
        }

        public bool Exists(long portfolioId)
        {
            return _context.Portfolio.Any(p => p.Id == portfolioId);
        }

        public PortfolioDto GetById(long id)
        {
            var portfolio = _context.Portfolio.Where(p => p.Id == id);
            var portfolioDto = _mapper.Map<PortfolioDto>(portfolio);
            return portfolioDto;
        }

        public void Create(PortfolioDto portfolioDto)
        {
            _context.Add(new Portfolio()
            {
                Name = portfolioDto.Name,
                IsLocked = false,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsDeleted = false,
                UserId = portfolioDto.UserId,
            });
            _context.SaveChanges();
        }

        public void Update(long portfolioId, PortfolioDto portfolioDto)
        {
            _context.Portfolio.Update(new Portfolio()
            {
                Id = portfolioId,
                Name = portfolioDto.Name,
                IsLocked = portfolioDto.IsLocked,
                CreatedOn = portfolioDto.CreatedOn,
                UpdatedOn = DateTime.UtcNow,
                UserId = portfolioDto.UserId,
            });
            _context.SaveChanges();
        }

        public void Delete(long portfolioId)
        {
            var existingPortfolio = _context.Portfolio.Find(portfolioId);
            if (existingPortfolio != null)
            {
                _context.Portfolio.Update(new Portfolio()
                {
                    UpdatedOn = DateTime.UtcNow,
                    IsDeleted = true,
                });
                _context.SaveChanges();
            }
        }
    }
}
