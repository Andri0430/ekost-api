using EKostApi.Dto;
using EKostApi.Models;

namespace EKostApi.Interface
{
    public interface IOwner
    {
        void RegisterOwner(DetailOwner detailOwner);
        void UpdateOwner(DetailOwner detailOwner);
        RequestOwnerDto GetOwnerByUsername(string username);
        RequestOwnerDto GetOwnerByEmail(string email);
        RequestOwnerDto GetOwnerByPhoneNumber(string phone);
        OwnerAccount GetAccountOwnerByUsername(string username);
    }
}