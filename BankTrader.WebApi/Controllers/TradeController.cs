using BankTrader.Application.Interfaces;
using BankTrader.Application.ViewModels;
using BankTrader.Infra.CrossCutting.Identity.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankTrader.WebApi.Controllers
{
    [Authorize]
    public class TradeController : ApiController
    {
        private readonly ITradeAppService _TradeAppService;
        
        public TradeController(ITradeAppService TradeAppService)
        {
            _TradeAppService = TradeAppService;
        }

        [AllowAnonymous]
        [HttpGet("trade")]
        public async Task<IActionResult> Get()
        {
            return CustomResponse(await _TradeAppService.GetAll());
        }

        [HttpPost("trade/identity-categories")]
        public IActionResult Post([FromBody] List<TradeViewModel> portfolio)
        {
            List<string> tradeCategories = new List<string>();

            if (!ModelState.IsValid)
                CustomResponse(ModelState);

            foreach (var item in portfolio)
            {
                switch (item.ClientSector.ToLower())
                {
                    case "private":
                        if (item.Value > 1000000)
                        {
                            tradeCategories.Add("HIGHRISK");
                        }
                        break;
                    case "public":
                        if (item.Value <= 1000000)
                        {
                            tradeCategories.Add("LOWRISK");
                        }
                        else if (item.Value > 1000000)
                        {
                            tradeCategories.Add("MEDIUMRISK");
                        }
                        break;
                }
                
            }
            return CustomResponse(tradeCategories);
        }


        [AllowAnonymous]
        [HttpGet("trade/{id:guid}")]
        public async Task<TradeViewModel> Get(Guid id)
        {
            return await _TradeAppService.GetById(id);
        }

        [CustomAuthorize("Trade", "Write")]
        [HttpPost("trade")]
        public async Task<IActionResult> Post([FromBody] TradeViewModel TradeViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _TradeAppService.RegisterORUpdate(TradeViewModel));
        }

        [CustomAuthorize("Trade", "Write")]
        [HttpPost("trade/register")]
        public async Task<IActionResult> PostNew([FromBody] TradeViewModel TradeViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _TradeAppService.RegisterORUpdate(TradeViewModel));
        }

        [CustomAuthorize("Trade", "Write")]
        [HttpPut("trade/update")]
        public async Task<IActionResult> PutEdit([FromBody] TradeViewModel TradeViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _TradeAppService.Update(TradeViewModel));
        }

        [CustomAuthorize("Trade", "Remove")]
        [HttpDelete("trade")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _TradeAppService.Remove(id));
        }
    }
}
