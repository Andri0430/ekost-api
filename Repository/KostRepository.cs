using EKostApi.Data;
using EKostApi.Interface;
using EKostApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EKostApi.Repository
{
    public class KostRepository : IKost
    {
        private readonly EkostContext _context;
        public KostRepository(EkostContext context)
        {
            _context = context;
        }

        public void CreateKost(DetailKost detailKost)
        {
            _context.DetailKosts.Add(detailKost);
            _context.SaveChanges();
        }

        public ICollection<Kost> GetAllKost()
        {
            return _context.Kost.Include(k => k.KostAdress).Include(k => k.KostType).ToList();
        }

        public ICollection<Kost> GetKostByCity(string city)
        {
            throw new NotImplementedException();
        }

        public Kost GetKostById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Kost> GetKostByIdTypeKost(int typeKostId)
        {
            throw new NotImplementedException();
        }

        public Kost GetKostByKostName(string kostName)
        {
            return _context.Kost.Where(k => k.KostName == kostName).FirstOrDefault()!;
        }
    }
}
