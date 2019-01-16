using Amara.UserManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;

namespace Amara.UserManagement.Controllers
{
    [Route("users")]
    public class UsersController: ControllerBase
    {
        private  IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Create([FromBody]User user)
        {
            if (user == null)
                return BadRequest();

            this._userService.AddUser(user);

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUser();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var user = this._userService.GetUserById(id);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody]User user, string id)
        {
            if (user == null)
                return BadRequest();

            this._userService.UpdateUser(id, user);

            return NoContent();
        }       

        // This should not be here
        //[HttpPost("login")]
        //public IActionResult Login([FromBody]LogIn user)
        //{
        //    return Ok(user);
        //}
    }
}
