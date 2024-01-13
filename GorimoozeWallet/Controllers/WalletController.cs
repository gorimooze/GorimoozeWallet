using GorimoozeWallet.Dto;
using GorimoozeWallet.Interfaces;
using GorimoozeWallet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GorimoozeWallet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var walletList = _walletService.GetList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(walletList);
        }

        [HttpGet("getById/{walletId}")]
        public IActionResult GetById(long walletId)
        {
            if (walletId == 0)
                return BadRequest(ModelState);

            if (_walletService.Exists(walletId))
            {
                ModelState.AddModelError("", "Portfolio was not found");
                return BadRequest(ModelState);
            }

            var walletDto = _walletService.GetById(walletId);

            return Ok(walletDto);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] WalletDto walletDto)
        {
            if (walletDto == null)
                return BadRequest(ModelState);

            if (walletDto.PortfolioId != null && walletDto.CurrencyId != null)
            {
                _walletService.Create(walletDto);
            }
            else
            {
                ModelState.AddModelError("", "You must have Portfolio and select one Currency");
                return BadRequest(ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("update/{walletId}")]
        public IActionResult Update(long walletId, [FromBody] WalletDto walletDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (walletId != walletDto.Id)
            {
                ModelState.AddModelError("", "Ids are not equal");
                return BadRequest(ModelState);
            }

            if (!_walletService.Exists(walletId))
                return NotFound();

            _walletService.Update(walletId, walletDto);

            return Ok("Successfully updated");
        }

        [HttpDelete("delete/{walletId}")]
        public IActionResult Delete(long walletId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_walletService.Exists(walletId))
                return NotFound();

            _walletService.Delete(walletId);

            return Ok("Successfully deleted");
        }
    }
}
