using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using timsoft.entities;
using timsoft.services;
using timsoft.Utils.SignInRequest;

namespace timsoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {

            _userService = userService;

        }



       [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] UserForm userForm)
        {

            User dbuser = new User();
            dbuser = _userService.AddUser(userForm);

            return Ok(dbuser);

        }



       /* [HttpPut]
        [Route("/addRoles")]
        public IActionResult AddRoles([FromBody] List<string> roles, int userId)
        {
            User dbuser = _userService.AddRoles(roles, userId);
            return Ok(dbuser);
        }
       */
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] SignIn signIn)
        {
            if (_userService.SignIn(signIn) == "wrong password")
            {
                return BadRequest("wrong password");
            }
            if (_userService.SignIn(signIn) == "wrong userName")
            {
                return BadRequest("wrong userName");
            }


            return Ok(new
            {
                token = _userService.SignIn(signIn),
                message = "Login successed !!"
            });

        }





    }
}
