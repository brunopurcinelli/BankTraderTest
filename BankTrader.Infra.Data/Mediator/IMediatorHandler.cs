using BankTrader.Domain.Core.Messaging;
using FluentValidation.Results;

namespace BankTrader.Infra.Data.Mediator
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
