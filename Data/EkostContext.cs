using EKostApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EKostApi.Data
{
    public class EkostContext : DbContext
    {
        public EkostContext(DbContextOptions options) : base(options) { }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<OwnerAccount> OwnerAccounts { get; set; }
        public DbSet<DetailOwner> DetailOwners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<DetailUser> DetailUsers { get; set; }
        public DbSet<KostType> kostTypes { get; set; }
        public DbSet<Kost> Kost { get; set; }
        public DbSet<DetailKost> DetailKosts { get; set; }
    }
}
