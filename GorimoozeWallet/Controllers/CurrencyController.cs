using GorimoozeWallet.Dto;
using GorimoozeWallet.Interfaces;
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

        [HttpGet("{currencyId}")]
        public IActionResult GetById(long currencyId)
        {
            if (currencyId == 0)
                return BadRequest(ModelState);

            var model = _currencyService.GetCurrencyById(currencyId);

            return Ok(model);
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
        public IActionResult Update(long currencyId, [FromBody] CurrencyDto currency)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _currencyService.Update(currency);

            return NoContent();
        }

        [HttpDelete("{currencyId}")]
        public IActionResult Delete(long currencyId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _currencyService.Delete(currencyId);

            return NoContent();
        }
    }
}
