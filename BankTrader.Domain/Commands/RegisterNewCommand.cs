using BankTrader.Domain.Commands.Validations;

namespace BankTrader.Domain.Commands
{
    public class RegisterNewCommand : TradeCommand
    {
        public RegisterNewCommand(double value, string clientSector)
        {
            Value = value;
            ClientSector = clientSector;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
