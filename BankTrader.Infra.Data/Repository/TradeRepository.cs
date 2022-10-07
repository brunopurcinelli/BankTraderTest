using BankTrader.Domain.Core.Interfaces;
using BankTrader.Domain.Interfaces;
using BankTrader.Domain.Models;
using BankTrader.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BankTrader.Infra.Data.Repository
{
    public class TradeRepository : ITradeRepository
    {
        protected readonly BankTraderContext Db;
        protected readonly DbSet<Trade> DbSet;

        public TradeRepository(BankTraderContext context)
        {
            Db = context;
            DbSet = Db.Set<Trade>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Trade> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<Trade> GetByClientSector(string clientSector)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.ClientSector == clientSector);
        }

        public async Task<IEnumerable<Trade>> GetAll()
        {
            return await DbSet.ToListAsync();
        }


        public void Add(Trade record)
        {
            DbSet.Add(record);
        }

        public void Update(Trade record)
        {
            DbSet.Update(record);
        }

        public void Remove(Trade record)
        {
            DbSet.Remove(record);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
