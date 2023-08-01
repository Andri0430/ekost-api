using EKostApi.Data;
using EKostApi.Dto;
using EKostApi.Interface;
using EKostApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EKostApi.Service
{
    public class AccountRepo : IAccount
    {
        private EkostContext _context;
        public AccountRepo(EkostContext context)
        {
            _context = context;
        }

        public Account GetAccountUsername(string username)
        {
            return _context.Accounts.Include(a => a.Role).Where(o => o.Username == username).FirstOrDefault()!;
        }

        public ICollection<RequestAccountDto> GetAllAccounts(int idRole)
        {
            var owner = _context.DetailAccount.Include(d => d.Account).Include(d => d.Account.Role).Where(d => d.Account.Role.Id == idRole).ToList();
            return owner.Select(owner => new RequestAccountDto
            {
                Name = owner.Name,
                Username = owner.Account.Username,
                Email = owner.Email,
                PhoneNumber = owner.PhoneNumber,
                Role = owner.Account.Role.RoleName
            }).ToList();
        }

        public RequestAccountDto GetAccountByEmail(string email, int idRole)
        {
            var owner = _context.DetailAccount.Include(d => d.Account).Include(d => d.Account.Role).Where(d => d.Email == email && d.Account.Role.Id == idRole).FirstOrDefault()!;
            if(owner != null)
            {
                return new RequestAccountDto
                {
                    Name = owner.Name,
                    Username = owner.Account.Username,
                    Email = owner.Email,
                    PhoneNumber = owner.PhoneNumber,
                    Role = owner.Account.Role.RoleName
                };
            }
            return null!;
        }

        public RequestAccountDto GetAccountByPhoneNumber(string phone, int idRole)
        {
            var owner = _context.DetailAccount.Include(d => d.Account).Include(d => d.Account.Role).Where(d => d.PhoneNumber == phone && d.Account.Role.Id == idRole).FirstOrDefault()!;
            if (owner != null)
            {
                return new RequestAccountDto
                {
                    Name = owner.Name,
                    Username = owner.Account.Username,
                    Email = owner.Email,
                    PhoneNumber = owner.PhoneNumber,
                    Role = owner.Account.Role.RoleName
                };
            }
            return null!;
        }

        public RequestAccountDto GetAccountByUsername(string username, int idRole)
        {
            var owner = _context.DetailAccount.Include(d => d.Account).Include(d => d.Account.Role).Where(d => d.Account.Username == username && d.Account.Role.Id == idRole).FirstOrDefault()!;
            if (owner != null)
            {
                return new RequestAccountDto
                {
                    Name = owner.Name,
                    Username = owner.Account.Username,
                    Email = owner.Email,
                    PhoneNumber = owner.PhoneNumber,
                    Role = owner.Account.Role.RoleName
                };
            }
            return null!;
        }

        public void RegisterAccount(DetailAccount detailAccount)
        {
            _context.DetailAccount.Add(detailAccount);
            _context.SaveChanges();
        }

        public void UpdateAccount(DetailAccount detailAccount)
        {
            _context.DetailAccount.Update(detailAccount);
            _context.SaveChanges();
        }

        public ICollection<RequestAccountDto> GetAllAccountByRole(int idRole)
        {
            var owner = _context.DetailAccount.Include(d => d.Account).Where(d => d.Account.Role.Id == idRole).ToList();
            if (owner != null)
            {
                return owner.Select(owner => new RequestAccountDto
                {
                    Name = owner.Name,
                    Username = owner.Account.Username,
                    Email = owner.Email,
                    PhoneNumber = owner.PhoneNumber,
                    Role = owner.Account.Role.RoleName

                }).ToList();
            }
            else
            {
                return new List<RequestAccountDto>();
            }
        }
    }
}
