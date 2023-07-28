using EKostApi.Models;

namespace EKostApi.Interface
{
    public interface IUser
    {
        void RegisterUser(DetailUser detailUser);
        void UpdateUser(DetailUser detailUser);
    }
}
