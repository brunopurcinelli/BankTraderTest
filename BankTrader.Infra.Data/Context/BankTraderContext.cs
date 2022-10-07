using BankTrader.Domain.Core.Interfaces;
using BankTrader.Domain.Core.Models;
using BankTrader.Domain.Models;
using BankTrader.Infra.Data.Mappings;
using BankTrader.Infra.Data.Mediator;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BankTrader.Infra.Data.Context
{

    public sealed class BankTraderContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public BankTraderContext(DbContextOptions<BankTraderContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public BankTraderContext(DbContextOptions<BankTraderContext> options, IMediatorHandler mediatorHandler) : this(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Trade> Traders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(150)");

            modelBuilder.ApplyConfiguration(new TradeMap());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            var success = await SaveChangesAsync() > 0;
            return success;
        }
    }
}
