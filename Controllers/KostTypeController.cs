using EKostApi.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EKostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KostTypeController : ControllerBase
    {
        private readonly IKostType _kostTypeRepo;
        public KostTypeController(IKostType kostTypeRepo)
        {
            _kostTypeRepo = kostTypeRepo;
        }

        [HttpGet]
        public IActionResult GetAllTypeKost()
        {
            return Ok(_kostTypeRepo.GetAllkostTypes());
        }

        [HttpGet("id")]
        public IActionResult GetTypeKostById(int id)
        {
            var kostId = _kostTypeRepo.GetKostTypeById(id);

            if(kostId== null)
            {
                return NotFound("Id Kost Tidak di Temukan!!!");
            }
            return Ok(kostId);
        }
    }
}
