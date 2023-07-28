using EKostApi.Data;
using EKostApi.Interface;
using EKostApi.Models;

namespace EKostApi.Service
{
    public class UserService : IUser
    {
        private readonly EkostContext _context;
        public UserService(EkostContext context)
        {
            _context = context;
        }

        public void RegisterUser(DetailUser detailUser)
        {
            _context.DetailUsers.Add(detailUser);
            _context.SaveChanges();
        }

        public void UpdateUser(DetailUser detailUser)
        {
            _context.DetailUsers.Update(detailUser);
            _context.SaveChanges();
        }
    }
}
