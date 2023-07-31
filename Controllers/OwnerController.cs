using EKostApi.Dto;
using EKostApi.Interface;
using EKostApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EKostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwner _ownerService;
        private readonly IConfiguration _configuration;

        public OwnerController(IOwner ownerService, IConfiguration configuration)
        {
            _ownerService = ownerService;
            _configuration = configuration;
        }

        [HttpGet("get-by-username")]
        public IActionResult GetOwnerByUsername(string username)
        {
            var usernameOnwer = _ownerService.GetOwnerByUsername(username);

            if(usernameOnwer == null) return NotFound("Username Tidak Ditemukan");
            return Ok(usernameOnwer);
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var username = _ownerService.GetOwnerByUsername(registerDto.Username);
            var email = _ownerService.GetOwnerByEmail(registerDto.Email);
            var phone = _ownerService.GetOwnerByPhoneNumber(registerDto.PhoneNumber);

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

                var createOwner = new DetailOwner
                {
                    OwnerAccount = new OwnerAccount
                    {
                        Username = registerDto.Username,
                        Password = hashPassword
                    },
                    Owner = new Owner
                    {
                        Name = registerDto.Name,
                        Email = registerDto.Email,
                        PhoneNumber = registerDto.PhoneNumber
                    }
                };
                _ownerService.RegisterOwner(createOwner);
                return Ok("Register Berhasil");
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var checkAccount = _ownerService.GetAccountOwnerByUsername(loginDto.Password);

            if (checkAccount == null)
            {
                return BadRequest("Account Not Found");
            }
            else
            {
                if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, checkAccount.Password))
                {
                    return BadRequest("Wrong Password");
                }

                string token = CreateToken(checkAccount);

                return Ok(token);
            }
        }

        private string CreateToken(OwnerAccount ownerAccount)
        {
            var owner = _ownerService.GetOwnerByUsername(ownerAccount.Username);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, owner.Name),
                new Claim(ClaimTypes.Email, owner.Email),
                new Claim(ClaimTypes.MobilePhone, owner.PhoneNumber)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(5),
                    signingCredentials: credential
                    );

            var sendToken = new JwtSecurityTokenHandler().WriteToken(token);
            return sendToken;
        }
    }
}
