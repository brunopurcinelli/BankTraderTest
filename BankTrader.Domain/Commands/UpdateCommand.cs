using BankTrader.Domain.Commands.Validations;

namespace BankTrader.Domain.Commands
{
    public class UpdateCommand : TradeCommand
    {
        public UpdateCommand(Guid id, double value, string clientSector)
        {
            Id = id;
            Value = value;
            ClientSector = clientSector;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
