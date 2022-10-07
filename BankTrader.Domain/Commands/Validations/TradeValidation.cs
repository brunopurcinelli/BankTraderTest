using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTrader.Domain.Commands.Validations
{
    public abstract class TradeValidation<T> : AbstractValidator<T> where T : TradeCommand
    {
        protected void ValidateValue()
        {
            RuleFor(c => c.Value)
                .NotEmpty()
                .Must(HaveValue);
        }

        protected void ValidateClientSector()
        {
            RuleFor(c => c.ClientSector)
                .NotEmpty().WithMessage("Please ensure you have entered the ClientSector")
                .Length(2, 150).WithMessage("The ClientSector must have between 2 and 150 characters");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool HaveValue(double value)
        {
            return value > 0;
        }
    }
}
