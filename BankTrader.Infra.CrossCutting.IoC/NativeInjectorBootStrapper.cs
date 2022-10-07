using BankTrader.Application.Interfaces;
using BankTrader.Application.Services;
using BankTrader.Domain.Commands;
using BankTrader.Domain.Interfaces;
using BankTrader.Infra.CrossCutting.Bus;
using BankTrader.Infra.Data.Context;
using BankTrader.Infra.Data.Mediator;
using BankTrader.Infra.Data.Repository;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BankTrader.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ITradeAppService, TradeAppService>();
                        
            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCommand, ValidationResult>, TradeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCommand, ValidationResult>, TradeCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCommand, ValidationResult>, TradeCommandHandler>();

            // Infra - Data
            services.AddScoped<ITradeRepository, TradeRepository>();
            services.AddScoped<BankTraderContext>();
        }
    }
}