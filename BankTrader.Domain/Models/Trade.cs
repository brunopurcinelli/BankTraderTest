using BankTrader.Domain.Core.Interfaces;
using BankTrader.Domain.Core.Models;

namespace BankTrader.Domain.Models
{
    public class Trade : Entity, IAggregateRoot
    {
        public Trade(Guid id, double? value, string? clientSector)
        {
            Id = id;
            Value = value;
            ClientSector = clientSector;
        }

        public double? Value { get; private set; }

        public string? ClientSector { get; private set; }
    }
}
