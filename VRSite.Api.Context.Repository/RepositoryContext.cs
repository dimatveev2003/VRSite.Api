using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VRSite.Api.Context.Repository.Contracts;
using VRSite.Api.Context.Repository.Entities;

namespace VRSite.Api.Context.Repository
{
    public class RepositoryContext : DbContext, IRepository
    {
        public DbSet<DbAuthData> AuthData { get; set; }
        public DbSet<DbClient> Clients { get; set; }
        public DbSet<DbLaboratory> Laboratories { get; set; }
        public DbSet<DbPrice> Prices { get; set; }
        public DbSet<DbCurrency> Currencies { get; set; }
        public DbSet<DbBundle> Bundles { get; set; }
        
        public DbSet<DbOrder> Orders { get; set; }
        public DbSet<DbBundleOrderItem> BundleOrderItems { get; set; }
        public DbSet<DbLaboratoryOrderItem> LaboratoryOrderItems { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public async Task SaveDbChangesAsync()
        {
            await SaveChangesAsync();
        }
    }
}
