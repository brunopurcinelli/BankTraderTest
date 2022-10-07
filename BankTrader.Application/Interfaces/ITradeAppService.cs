using BankTrader.Application.ViewModels;
using FluentValidation.Results;

namespace BankTrader.Application.Interfaces
{
    public interface ITradeAppService : IDisposable
    {
        Task<IEnumerable<TradeViewModel>> GetAll();
        Task<TradeViewModel> GetById(Guid id);

        Task<ValidationResult> RegisterORUpdate(TradeViewModel TradeViewModel);
        Task<ValidationResult> Register(TradeViewModel TradeViewModel);
        Task<ValidationResult> Update(TradeViewModel TradeViewModel);
        Task<ValidationResult> Remove(Guid id);

        //Task<IList<TradeHistoryData>> GetAllHistory(Guid id);
    }
}
