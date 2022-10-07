namespace BankTrader.Domain.Commands.Validations
{
    public class RegisterNewCommandValidation : TradeValidation<RegisterNewCommand>
    {
        public RegisterNewCommandValidation()
        {
            ValidateValue();
            ValidateClientSector();
        }
    }
}
