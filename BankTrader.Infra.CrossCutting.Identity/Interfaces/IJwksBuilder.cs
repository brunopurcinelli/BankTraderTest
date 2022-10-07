using Microsoft.Extensions.DependencyInjection;

namespace BankTrader.Infra.CrossCutting.Identity.Interfaces
{
    public interface IJwksBuilder
    {
        IServiceCollection Services { get; }
    }
}
