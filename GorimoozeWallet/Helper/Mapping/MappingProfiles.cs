using AutoMapper;
using GorimoozeWallet.Dto;
using GorimoozeWallet.Models;

namespace GorimoozeWallet.Helper.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Currency, CurrencyDto>();
            CreateMap<CurrencyDto, Currency>();
        }
    }
}
