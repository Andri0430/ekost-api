using EKostApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EKostApi.Data
{
    public class EkostContext : DbContext
    {
        public EkostContext(DbContextOptions options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<DetailAccount> DetailAccount { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<KostType> kostTypes { get; set; }
        public DbSet<Kost> Kost { get; set; }
        public DbSet<DetailKost> DetailKosts { get; set; }
    }
}
