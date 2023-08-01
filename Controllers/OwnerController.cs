using EKostApi.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EKostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IAccount _accountService;
        private readonly IRole _roleService;

        public OwnerController(IAccount accountService, IRole roleService)
        {
            _accountService = accountService;
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAllOwners()
        {
            return Ok(_accountService.GetAllAccounts(1));
        }

        [HttpGet("get-by-username")]
        public IActionResult GetOwnerByUsername(string usernama)
        {
            var owner = _accountService.GetAccountByUsername(usernama,1);

            if (owner == null) return NotFound("Username Tidak Ditemukan");
            return Ok(owner);
        }

        [HttpGet("get-by-email")]
        public IActionResult GetOwnerByEmail(string usernama)
        {
            var owner = _accountService.GetAccountByEmail(usernama,1);

            if (owner == null) return NotFound("Username Tidak Ditemukan");
            return Ok(owner);
        }

        [HttpGet("get-by-phone")]
        public IActionResult GetOwnerByPhone(string phone)
        {
            var owner = _accountService.GetAccountByPhoneNumber(phone,1);

            if (owner == null) return NotFound("Username Tidak Ditemukan");
            return Ok(owner);
        }
    }
}
