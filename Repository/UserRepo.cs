using EKostApi.Data;
using EKostApi.Interface;
using EKostApi.Models;

namespace EKostApi.Service
{
    public class UserRepo : IUser
    {
        private readonly EkostContext _context;
        public UserRepo(EkostContext context)
        {
            _context = context;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).FirstOrDefault()!;
        }

        public User GetUserByPhoneNumber(string phone)
        {
            return _context.Users.Where(u => u.PhoneNumber == phone).FirstOrDefault()!;
        }

        public UserAccount GetUserByUsername(string username)
        {
            return _context.UserAccounts.Where(u => u.Username == username).FirstOrDefault()!;
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
