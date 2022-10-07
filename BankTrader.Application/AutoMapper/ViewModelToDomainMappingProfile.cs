using AutoMapper;
using BankTrader.Application.ViewModels;
using BankTrader.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTrader.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TradeViewModel, RegisterNewCommand>()
                .ConstructUsing(c => new RegisterNewCommand(c.Value, c.ClientSector));
            CreateMap<TradeViewModel, UpdateCommand>()
                .ConstructUsing(c => new UpdateCommand(c.Id, c.Value, c.ClientSector));
        }
    }
}
