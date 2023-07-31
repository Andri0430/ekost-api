using EKostApi.Models;

namespace EKostApi.Interface
{
    public interface IUser
    {
        void RegisterUser(DetailUser detailUser);
        void UpdateUser(DetailUser detailUser);
        UserAccount GetUserByUsername(string username);
        User GetUserByEmail(string email);
        User GetUserByPhoneNumber(string phone);
    }
}
