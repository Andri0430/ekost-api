using EKostApi.Dto;
using EKostApi.Interface;
using EKostApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EKostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        public UserController(IUser userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var username = _userService.GetUserByUsername(registerDto.Username);
            var email = _userService.GetUserByEmail(registerDto.Email);
            var phone = _userService.GetUserByPhoneNumber(registerDto.PhoneNumber);

            if (username != null)
            {
                return BadRequest("Username sudah digunakan");
            }
            else if (email != null)
            {
                return BadRequest("Email sudah digunakan");
            }
            else if (phone != null)
            {
                return BadRequest("Phone sudah digunakan");
            }
            else
            {
                string saltPassword = BCrypt.Net.BCrypt.GenerateSalt();
                string hashPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password, saltPassword);

                var createUser = new DetailUser
                {
                    UserAccount = new UserAccount
                    {
                        Username = registerDto.Username,
                        Password = hashPassword
                    },
                    User = new User
                    {
                        Name = registerDto.Name,
                        Email = registerDto.Email,
                        PhoneNumber = registerDto.PhoneNumber
                    }
                };
                _userService.RegisterUser(createUser);
                return Ok("Register Berhasil");
            }
        }
    }
}
