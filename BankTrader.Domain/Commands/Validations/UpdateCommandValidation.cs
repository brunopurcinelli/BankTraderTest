namespace BankTrader.Domain.Commands.Validations
{
    public class UpdateCommandValidation : TradeValidation<UpdateCommand>
    {
        public UpdateCommandValidation()
        {
            ValidateId();
            ValidateValue();
            ValidateClientSector();
        }
    }
}
