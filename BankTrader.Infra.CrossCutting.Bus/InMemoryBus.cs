using BankTrader.Domain.Core.Messaging;
using BankTrader.Infra.Data.Mediator;
using FluentValidation.Results;
using MediatR;

namespace BankTrader.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}