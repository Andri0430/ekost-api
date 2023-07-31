using EKostApi.Data;
using EKostApi.Dto;
using EKostApi.Interface;
using EKostApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EKostApi.Service
{
    public class OwnerRepo : IOwner
    {
        private EkostContext _context;
        public OwnerRepo(EkostContext context)
        {
            _context = context;
        }

        public OwnerAccount GetAccountOwnerByUsername(string username)
        {
            return _context.OwnerAccounts.Where(o => o.Username == username).FirstOrDefault()!;
        }

        public RequestOwnerDto GetOwnerByEmail(string email)
        {
            var ownerEmail = _context.DetailOwners.Include(d => d.Owner).Include(d => d.OwnerAccount).Where(d => d.Owner.Email == email).FirstOrDefault()!;
            if(ownerEmail != null)
            {
                return new RequestOwnerDto
                {
                    Name = ownerEmail.Owner.Name,
                    Username = ownerEmail.OwnerAccount.Username,
                    Email = ownerEmail.Owner.Email,
                    PhoneNumber = ownerEmail.Owner.PhoneNumber
                };
            }
            return null!;
        }

        public RequestOwnerDto GetOwnerByPhoneNumber(string phone)
        {
            var ownerPhoneNumber = _context.DetailOwners.Include(d => d.Owner).Include(d => d.OwnerAccount).Where(d => d.Owner.PhoneNumber == phone).FirstOrDefault()!;
            if (ownerPhoneNumber != null)
            {
                return new RequestOwnerDto
                {
                    Name = ownerPhoneNumber.Owner.Name,
                    Username = ownerPhoneNumber.OwnerAccount.Username,
                    Email = ownerPhoneNumber.Owner.Email,
                    PhoneNumber = ownerPhoneNumber.Owner.PhoneNumber
                };
            }
            return null!;
        }

        public RequestOwnerDto GetOwnerByUsername(string username)
        {
            var ownerUsername = _context.DetailOwners.Include(d => d.Owner).Include(d => d.OwnerAccount).Where(d => d.OwnerAccount.Username == username).FirstOrDefault()!;
            if(ownerUsername != null)
            {
                return new RequestOwnerDto
                {
                    Name = ownerUsername.Owner.Name,
                    Username = ownerUsername.OwnerAccount.Username,
                    Email = ownerUsername.Owner.Email,
                    PhoneNumber = ownerUsername.Owner.PhoneNumber
                };
            }
            return null!;
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
