using GorimoozeWallet.Dto;
using GorimoozeWallet.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult GetAll()
        {
            var wallets = _walletService.GetWalletList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(wallets);
        }

        [HttpGet("{userId}")]
        public IActionResult GetByUserId(long userId)
        {
            var wallet = _walletService.GetWalletByUserId(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(wallet);
        }

        [HttpPost]
        public IActionResult Create([FromBody] WalletDto wallet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _walletService.Create(wallet);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] WalletDto wallet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _walletService.Update(wallet);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _walletService.Delete(id);
            return Ok();
        }
    }
}
