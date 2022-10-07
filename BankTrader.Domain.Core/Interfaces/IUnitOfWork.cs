namespace BankTrader.Domain.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
