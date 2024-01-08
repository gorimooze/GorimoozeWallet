using GorimoozeWallet.Dto;
using GorimoozeWallet.Helper.Extensions;
using GorimoozeWallet.Interfaces;
using GorimoozeWallet.Services;
using Microsoft.AspNetCore.Authorization;
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
        
        [HttpPost("create")]
        public IActionResult Create([FromBody] PortfolioDto portfolioDto)
        {
            if (portfolioDto == null)
                return BadRequest(ModelState);
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _configuration.GetUserIdFromToken(token);

            if (userId != null)
            {
                portfolioDto.UserId = (long)userId;
            }
            else
            {
                ModelState.AddModelError("", "User was not found, apparently it is necessary to authorize again");
                return BadRequest(ModelState);
            }

            _portfolioService.Create(portfolioDto);

            return Ok("Successfully created");
        }
    }
}
