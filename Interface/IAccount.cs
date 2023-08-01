using EKostApi.Dto;
using EKostApi.Models;

namespace EKostApi.Interface
{
    public interface IAccount
    {
        void RegisterAccount(DetailAccount detailAccount);
        void UpdateAccount(DetailAccount detailAccount);
        RequestAccountDto GetAccountByUsername(string username, int idRole);
        RequestAccountDto GetAccountByEmail(string email, int idRole);
        RequestAccountDto GetAccountByPhoneNumber(string phone, int idRole);
        ICollection<RequestAccountDto> GetAllAccounts(int idRole);
        ICollection<RequestAccountDto> GetAllAccountByRole(int idRole);
        Account GetAccountUsername(string username);
    }
}