using BankTrader.Domain.Core.Messaging;

namespace BankTrader.Domain.Commands
{
    public abstract class TradeCommand : Command
    {
        public Guid Id { get; protected set; }

        public double Value { get; protected set; }

        public string ClientSector { get; protected set; }
    }
}
