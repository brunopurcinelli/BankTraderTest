namespace BankTrader.Domain.Commands.Validations
{
    public class RemoveCommandValidation : TradeValidation<RemoveCommand>
    {
        public RemoveCommandValidation()
        {
            ValidateId();
        }
    }
}
