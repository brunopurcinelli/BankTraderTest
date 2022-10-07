using BankTrader.Infra.CrossCutting.Identity.Interfaces;
using BankTrader.Infra.CrossCutting.Identity.Jwa;
using BankTrader.Infra.CrossCutting.Identity.Store;
using Microsoft.Extensions.DependencyInjection;

namespace BankTrader.Infra.CrossCutting.Identity.Jwt.Core
{
    public class JwtOptions
    {
        public Algorithm Jws { get; set; } = Algorithm.Create(AlgorithmType.RSA, JwtType.Jws);
        public Algorithm Jwe { get; set; } = Algorithm.Create(AlgorithmType.RSA, JwtType.Jwe);
        public int DaysUntilExpire { get; set; } = 90;
        public string KeyPrefix { get; set; } = $"{Environment.MachineName}_";
        public int AlgorithmsToKeep { get; set; } = 2;
        public TimeSpan CacheTime { get; set; } = TimeSpan.FromMinutes(15);
    }

    public class JwksBuilder : IJwksBuilder
    {

        public JwksBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public IServiceCollection Services { get; }
    }

    public class JwkContants
    {
        public static string CurrentJwkCache => $"NETDEVPACK-CURRENT-SECURITY-KEY";
        public static string JwksCache => $"NETDEVPACK-JWKS";
    }

    public static class JsonWebKeySetManagerDependencyInjection
    {
        /// <summary>
        /// Sets the signing credential.
        /// </summary>
        /// <returns></returns>
        public static IJwksBuilder AddJwksManager(this IServiceCollection services, Action<JwtOptions> action = null)
        {
            if (action != null)
                services.Configure(action);

            services.AddDataProtection();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IJsonWebKeyStore, DataProtectionStore>();

            return new JwksBuilder(services);
        }

        /// <summary>
        /// Sets the signing credential.
        /// </summary>
        /// <returns></returns>
        public static IJwksBuilder PersistKeysInMemory(this IJwksBuilder builder)
        {
            builder.Services.AddScoped<IJsonWebKeyStore, InMemoryStore>();

            return builder;
        }
    }
}
