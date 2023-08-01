using EKostApi.Data;
using EKostApi.Interface;
using EKostApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EKostApi.Repository
{
    public class RoleRepo : IRole
    {
        private readonly EkostContext _ekostContext;
        public RoleRepo(EkostContext ekostContext)
        {
            _ekostContext = ekostContext;
        }

        public Role GetRoleId(int id)
        {
            return _ekostContext.Roles.Where(r => r.Id == id).FirstOrDefault()!;
        }
    }
}