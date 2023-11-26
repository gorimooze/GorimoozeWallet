using GorimoozeWallet.Dto;
using GorimoozeWallet.Interfaces;
using GorimoozeWallet.Models;
using GorimoozeWallet.Services;
using Microsoft.AspNetCore.Mvc;

namespace GorimoozeWallet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User model)
        {
            if (model == null)
                return BadRequest("Sorry, but you need to fill the required fields.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _userService.Create(model);



            return Ok("Successfully created");
        }
    }
}
