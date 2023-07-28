using EKostApi.Data;
using EKostApi.Interface;
using EKostApi.Models;

namespace EKostApi.Service
{
    public class OwnerService : IOwner
    {
        private EkostContext _context;
        public OwnerService(EkostContext context)
        {
            _context = context;
        }

        public void RegisterOwner(DetailOwner detailOwner)
        {
            _context.DetailOwners.Add(detailOwner);
            _context.SaveChanges();
        }

        public void UpdateOwner(DetailOwner detailOwner)
        {
            _context.DetailOwners.Update(detailOwner);
            _context.SaveChanges();
        }
    }
}
