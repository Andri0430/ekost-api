using EKostApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EKostApi.Data
{
    public class EkostContext : DbContext
    {
        public EkostContext(DbContextOptions options) : base(options) { }
        public DbSet<DetailOwner> DetailOwners { get; set; }
    }
}
