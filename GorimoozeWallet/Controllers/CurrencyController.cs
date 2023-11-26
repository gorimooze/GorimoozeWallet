using GorimoozeWallet.Data;
using GorimoozeWallet.Dto;
using GorimoozeWallet.Interfaces;
using GorimoozeWallet.Services;
using Microsoft.AspNetCore.Mvc;

namespace GorimoozeWallet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _currencyService.GetCurrencyList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }


        [HttpPost]
        public IActionResult Create([FromBody] CurrencyDto currency)
        {
            if (currency == null)
                return BadRequest(ModelState);

            _currencyService.Create(currency);

            return Ok("Successfully created");
        }

        [HttpPut("{currencyId}")]
        public IActionResult Update(int currencyId, [FromBody] CurrencyDto currency)
        {
            if (currency == null)
                return BadRequest(ModelState);

            _currencyService.Update(currency);

            return NoContent();
            var existCurrency = _currencyService.GetCurrencyById(currencyId);


        }

        [HttpDelete("{currencyId}")]
        public IActionResult Delete(int currencyId)
        {
            var existCurrency = _currencyService.GetCurrencyById(currencyId);
            if (existCurrency == null)
            {
                return NotFound();
            }

            _currencyService.Delete(existCurrency);

            return NoContent();
        }
    }
}
