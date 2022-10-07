using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankTrader.Infra.CrossCutting.Identity.Data
{
    public class BankTraderAppDbContext : IdentityDbContext
    {
        public BankTraderAppDbContext(DbContextOptions<BankTraderAppDbContext> options) : base(options) { }
    }
}
