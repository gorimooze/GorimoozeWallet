using GorimoozeWallet.Dto;
using GorimoozeWallet.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GorimoozeWallet.Controllers
{
    [ApiController]
    [Route("currency")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }


        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var currencies = _currencyService.GetCurrencyList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(currencies);
        }

        [HttpGet("getById/{currencyId}")]
        public IActionResult GetById(long currencyId)
        {
            if (currencyId == 0)
                return BadRequest(ModelState);

            var model = _currencyService.GetCurrencyById(currencyId);

            return Ok(model);
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm] CurrencyDto currencyDto)
        {
            if (currencyDto == null)
                return BadRequest(ModelState);

            _currencyService.Create(currencyDto);

            return Ok("Successfully created");
        }

        [HttpPut("update/{currencyId}")]
        public IActionResult Update(long currencyId, [FromBody] CurrencyDto currencyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (currencyId != currencyDto.Id)
                return BadRequest(ModelState);

            if (!_currencyService.CurrencyExists(currencyId))
                return NotFound();

            _currencyService.Update(currencyId, currencyDto);

            return Ok("Successfully updated");
        }

        [HttpDelete("delete/{currencyId}")]
        public IActionResult Delete(long currencyId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_currencyService.CurrencyExists(currencyId))
                return NotFound();

            _currencyService.Delete(currencyId);

            return Ok("Successfully deleted");
        }
    }
}
