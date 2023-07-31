using EKostApi.Data;
using EKostApi.Interface;
using EKostApi.Models;

namespace EKostApi.Repository
{
    public class KostTypeRepo : IKostType
    {
        private readonly EkostContext _context;
        public KostTypeRepo(EkostContext context)
        {
            _context = context;
        }
        public KostType GetKostTypeById(int id)
        {
            return _context.kostTypes.Where(k => k.Id == id).FirstOrDefault()!;
        }

        public ICollection<KostType> GetAllkostTypes()
        {
            return _context.kostTypes.ToList();
        }
    }
}