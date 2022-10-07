using BankTrader.Infra.CrossCutting.Identity.Model;
using System.Collections.ObjectModel;

namespace BankTrader.Infra.CrossCutting.Identity.Interfaces
{
    public interface IJsonWebKeyStore
    {
        Task Store(KeyMaterial keyMaterial);
        Task<KeyMaterial> GetCurrent();
        Task Revoke(KeyMaterial keyMaterial);
        Task<ReadOnlyCollection<KeyMaterial>> GetLastKeys(int quantity);
        Task<KeyMaterial> Get(string keyId);
        Task Clear();
    }
}
