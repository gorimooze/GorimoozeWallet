using GorimoozeWallet.Dto;
using GorimoozeWallet.Helper.Extensions;
using GorimoozeWallet.Interfaces;
using GorimoozeWallet.Models;
using Microsoft.AspNetCore.Mvc;

namespace GorimoozeWallet.Controllers
{
    [ApiController]
    [Route("portfolio")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IConfiguration _configuration;

        public PortfolioController(IPortfolioService portfolioService, IConfiguration configuration)
        {
            _portfolioService = portfolioService;
            _configuration = configuration;
        }


        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var portfolioList = _portfolioService.GetList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(portfolioList);
        }

        [HttpGet("getById/{portfolioId}")]
        public IActionResult GetById(long portfolioId)
        {
            if (portfolioId == 0)
                return BadRequest(ModelState);

            if (_portfolioService.Exists(portfolioId))
            {
                ModelState.AddModelError("", "Portfolio was not found");
                return BadRequest(ModelState);
            }

            var portfolioDto = _portfolioService.GetById(portfolioId);

            return Ok(portfolioDto);
        }

        [HttpGet("getAllByToken")]
        public IActionResult GetAllByToken()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _configuration.GetUserIdFromToken(token);
            ICollection<Portfolio> portfolioList = new List<Portfolio>();

            if (userId != null)
            {
                portfolioList = _portfolioService.GetListByUserId(userId.Value);
            }
            else
            {
                ModelState.AddModelError("", "User was not found, apparently it is necessary to authorize again");
                return BadRequest(ModelState);
            }

            return Ok(portfolioList);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] PortfolioDto portfolioDto)
        {
            if (portfolioDto == null)
                return BadRequest(ModelState);
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _configuration.GetUserIdFromToken(token);

            if (userId != null)
            {
                portfolioDto.UserId = userId.Value;
            }
            else
            {
                ModelState.AddModelError("", "User was not found, apparently it is necessary to authorize again");
                return BadRequest(ModelState);
            }

            _portfolioService.Create(portfolioDto);

            return Ok("Successfully created");
        }

        [HttpPut("update/{portfolioId}")]
        public IActionResult Update(long portfolioId, [FromBody] PortfolioDto portfolioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (portfolioId != portfolioDto.Id)
            {
                ModelState.AddModelError("", "Ids are not equal");
                return BadRequest(ModelState);
            }

            if (!_portfolioService.Exists(portfolioId))
                return NotFound();

            _portfolioService.Update(portfolioId, portfolioDto);

            return Ok("Successfully updated");
        }

        [HttpDelete("delete/{portfolioId}")]
        public IActionResult Delete(long portfolioId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_portfolioService.Exists(portfolioId))
                return NotFound();

            _portfolioService.Delete(portfolioId);

            return Ok("Successfully deleted");
        }
    }
}
