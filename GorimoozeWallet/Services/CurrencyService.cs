using AutoMapper;
using GorimoozeWallet.Data;
using GorimoozeWallet.Dto;
using GorimoozeWallet.Interfaces;
using GorimoozeWallet.Models;

namespace GorimoozeWallet.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly GorimoozeWalletDbContext _context;
        private readonly IMapper _mapper;

        public CurrencyService(GorimoozeWalletDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<Currency> GetCurrencyList()
        {
            return _context.Currency.ToList();
        }

        public bool CurrencyExists(long currencyId)
        {
            return _context.Currency.Any(c => c.Id == currencyId);
        }

        public CurrencyDto GetCurrencyById(long id)
        {
            var currency = _context.Currency.Where(c => c.Id == id).FirstOrDefault();
            var currencyDto = _mapper.Map<CurrencyDto>(currency);
            return currencyDto;
        }

        public void Create(CurrencyDto currencyDto)
        {
            var currency = new Currency()
            {
                Name = currencyDto.Name,
                ShortName = currencyDto.ShortName,
                StateActivity = currencyDto.StateActivity,
                IsActive = currencyDto.IsActive,
            };

            if (currencyDto.Image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    currencyDto.Image.CopyTo(memoryStream);
                    currency.Image = memoryStream.ToArray();
                }
            }

            _context.Add(currency);
            _context.SaveChanges();
        }

        public void Update(long currencyId, CurrencyDto currencyDto)
        {
            var currency = _mapper.Map<Currency>(currencyDto);
            _context.Currency.Update(currency);
            _context.SaveChanges();
        }

        public void Delete(long currencyId)
        {
            var existingCurrency = _context.Currency.Find(currencyId);
            if (existingCurrency != null)
            {
                _context.Currency.Remove(existingCurrency);
                _context.SaveChanges();
            }
        }
    }
}
