using System;
using System.Threading;
using System.Threading.Tasks;
using BankTrader.Domain.Core.Messaging;
using BankTrader.Domain.Interfaces;
using BankTrader.Domain.Models;
using FluentValidation.Results;
using MediatR;

namespace BankTrader.Domain.Commands
{
    public class TradeCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCommand, ValidationResult>,
        IRequestHandler<UpdateCommand, ValidationResult>,
        IRequestHandler<RemoveCommand, ValidationResult>
    {
        private readonly ITradeRepository _TradeRepository;

        public TradeCommandHandler(ITradeRepository TradeRepository)
        {
            _TradeRepository = TradeRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var trade = new Trade(Guid.NewGuid(), message.Value, message.ClientSector);

            if (await _TradeRepository.GetByClientSector(trade.ClientSector) != null)
            {
                AddError("The Trade ClientSector has already been taken.");
                return ValidationResult;
            }

            _TradeRepository.Add(trade);

            return await Commit(_TradeRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var trade = new Trade(message.Id, message.Value, message.ClientSector);
            var existingTrade = await _TradeRepository.GetByClientSector(trade.ClientSector);

            if (existingTrade != null && existingTrade.Id != trade.Id)
            {
                if (!existingTrade.Equals(trade))
                {
                    AddError("The Trade e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            _TradeRepository.Update(trade);

            return await Commit(_TradeRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var trade = await _TradeRepository.GetById(message.Id);

            if (trade is null)
            {
                AddError("The Trade doesn't exists.");
                return ValidationResult;
            }

            _TradeRepository.Remove(trade);

            return await Commit(_TradeRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _TradeRepository.Dispose();
        }
    }
}
