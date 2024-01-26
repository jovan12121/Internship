using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Interfaces;
using TaskTracker.Models;
using TaskTracker.Services;

namespace TaskTracker.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _usersService;

        public UsersController(IUserService userService) 
        {
            _usersService = userService;
        }
        [HttpPost("register")]
        public ActionResult Register(User user)
        {
            try
            {
                return Ok(_usersService.Register(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("login")]
        public ActionResult Login(string username,string password)
        {
            try
            {
                return Ok(_usersService.Login(username,password));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
