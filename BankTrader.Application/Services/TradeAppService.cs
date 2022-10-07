using AutoMapper;
using BankTrader.Application.Interfaces;
using BankTrader.Application.ViewModels;
using BankTrader.Domain.Commands;
using BankTrader.Domain.Interfaces;
using BankTrader.Infra.Data.Mediator;
using FluentValidation.Results;

namespace BankTrader.Application.Services
{
    public class TradeAppService : ITradeAppService
    {
        private readonly IMapper _mapper;
        private readonly ITradeRepository _TradeRepository;
        private readonly IMediatorHandler _mediator;

        public TradeAppService(IMapper mapper,
                                  ITradeRepository TradeRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _TradeRepository = TradeRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<TradeViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<TradeViewModel>>(await _TradeRepository.GetAll());
        }

        public async Task<TradeViewModel> GetById(Guid id)
        {
            return _mapper.Map<TradeViewModel>(await _TradeRepository.GetById(id));
        }

        public async Task<ValidationResult> RegisterORUpdate(TradeViewModel TradeViewModel)
        {
            TradeViewModel findTrade = await GetById(TradeViewModel.Id);

            if (findTrade != null)
            {
                return await Register(TradeViewModel);
            }
            else
            {
                return await Update(TradeViewModel);
            }
        }

        public async Task<ValidationResult> Register(TradeViewModel TradeViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCommand>(TradeViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(TradeViewModel TradeViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCommand>(TradeViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
