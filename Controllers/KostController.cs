using EKostApi.Dto;
using EKostApi.Interface;
using EKostApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace EKostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KostController : ControllerBase
    {
        private readonly IKost _kostService;
        private readonly IKostType _kostTypeService;
        public KostController(IKost kostService, IKostType kostTypeService)
        {
            _kostService = kostService;
            _kostTypeService = kostTypeService;
        }

        [HttpPost("create-kost")]
        public IActionResult CreateKost(CreateKostDto createKostDto)
        {
            var typeKostId = _kostTypeService.GetKostTypeById(createKostDto.IdTypeKost);
            var kostName = _kostService.GetKostByKostName(createKostDto.KostName);

            if(typeKostId == null)
            {
                return NotFound("Id Type Kost Tidak di temukan!!!");
            }
            else if(kostName != null)
            {
                return BadRequest("Nama kost sudah pernah digunakan");
            }
            else
            {
                var addNewKost = new DetailKost
                {
                    Kost = new Kost
                    {
                        KostName = createKostDto.KostName,
                        KostPrice = createKostDto.KostPrice,
                        KostType = typeKostId,
                        KostAdress = new KostAdress
                        {
                            City = createKostDto.City,
                            Province = createKostDto.Province,
                            District = createKostDto.District,
                            Street = createKostDto.Street
                        }
                    },
                    QtyRoom = createKostDto.QtyRoom
                };
                _kostService.CreateKost(addNewKost);
                return Ok("Tambah Kost Berhasil");
            }
        }
    }
}
