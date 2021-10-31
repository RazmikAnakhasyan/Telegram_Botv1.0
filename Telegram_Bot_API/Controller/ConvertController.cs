using Microsoft.AspNetCore.Mvc;
using Core.Services;
using Shared.Models;

namespace API.Controller
{
    [ApiController]
    [Route("api/[controller]/convert")]
    public class ConvertController : ControllerBase
    {
        private readonly IBestAvailableRateService _bestAvailableRate;

        public ConvertController(IBestAvailableRateService bestAvailableRate)
        {
            _bestAvailableRate = bestAvailableRate;
        }

        [HttpGet]
        public IActionResult Get(string fromCurrency, string toCurrency, decimal amount)
        {
            BestAvailableRate r = _bestAvailableRate.GetBestAvailableRate(fromCurrency, toCurrency, amount);
            return Content(@"value :"+ r.Amount +", best :" + r.BankName);
        }

    }
}
