using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VRSite.Api.Context.Repository.Entities;

namespace VRSite.Api.Context.Repository.Contracts
{
    public interface IRepository : IDisposable
    {
        DbSet<DbAuthData> AuthData { get; set; }

        DbSet<DbClient> Clients { get; set; }

        DbSet<DbLaboratory> Laboratories { get; set; }

        DbSet<DbPrice> Prices { get; set; }

        DbSet<DbCurrency> Currencies { get; set; }

        DbSet<DbBundle> Bundles { get; set; }
        
        DbSet<DbOrder> Orders { get; set; }
        
        DbSet<DbBundleOrderItem> BundleOrderItems { get; set; }
        
        DbSet<DbLaboratoryOrderItem> LaboratoryOrderItems { get; set; }

        Task SaveDbChangesAsync();
    }
}
