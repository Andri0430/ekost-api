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
    public class AccountController : ControllerBase
    {
        private readonly IAccount _accountService;
        private readonly IRole _roleService;
        private readonly IConfiguration _configuration;

        public AccountController(IAccount accountService, IConfiguration configuration, IRole roleService)
        {
            _accountService = accountService;
            _roleService = roleService;
            _configuration = configuration;
        }

        [HttpGet("get-account-by-role")]
        public IActionResult GetAccountByRole(int idRole)
        {
            var role = _roleService.GetRoleId(idRole);
            if (role == null) return NotFound("Id role tidak di temukan");
            return Ok(_accountService.GetAllAccountByRole(idRole));
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var username = _accountService.GetAccountByUsername(registerDto.Username, registerDto.IdRole);
            var email = _accountService.GetAccountByEmail(registerDto.Email, registerDto.IdRole);
            var phone = _accountService.GetAccountByPhoneNumber(registerDto.PhoneNumber, registerDto.IdRole);

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

                var createAccount = new DetailAccount
                {
                    Account = new Account
                    {
                        Username = registerDto.Username,
                        Password = hashPassword,
                        Role = _roleService.GetRoleId(registerDto.IdRole)
                    },
                    Name = registerDto.Name,
                    Email = registerDto.Email,
                    PhoneNumber = registerDto.PhoneNumber
                };
                _accountService.RegisterAccount(createAccount);
                return Ok("Register Berhasil");
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var checkAccount = _accountService.GetAccountUsername(loginDto.Username);

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

        private string CreateToken(Account account)
        {
            var owner = _accountService.GetAccountByUsername(account.Username, account.Role.Id);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, owner.Name),
                new Claim(ClaimTypes.Email, owner.Email),
                new Claim(ClaimTypes.MobilePhone, owner.PhoneNumber),
                new Claim(ClaimTypes.Role, owner.Role)
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
