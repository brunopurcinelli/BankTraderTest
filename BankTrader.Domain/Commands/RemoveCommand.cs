using BankTrader.Domain.Commands.Validations;

namespace BankTrader.Domain.Commands
{
    public class RemoveCommand : TradeCommand
    {
        public RemoveCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
