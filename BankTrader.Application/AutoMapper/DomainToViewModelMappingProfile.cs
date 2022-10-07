using AutoMapper;
using BankTrader.Application.ViewModels;
using BankTrader.Domain.Models;

namespace BankTrader.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Trade, TradeViewModel>();
        }
    }
}
