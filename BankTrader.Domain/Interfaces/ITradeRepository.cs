using BankTrader.Domain.Core.Interfaces;
using BankTrader.Domain.Models;

namespace BankTrader.Domain.Interfaces
{
    public interface ITradeRepository : IRepository<Trade>
    {
        Task<Trade> GetById(Guid id);
        Task<Trade> GetByClientSector(string clientSector);
        Task<IEnumerable<Trade>> GetAll();

        void Add(Trade record);
        void Update(Trade record);
        void Remove(Trade record);
    }
}
