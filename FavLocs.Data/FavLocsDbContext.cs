using System.Data.Entity;
using FavLocs.Data.Contracts;
using FavLocs.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FavLocs.Data
{
    public class FavLocsDbContext : IdentityDbContext<User>, IFavLocsDbContext
    {
        public FavLocsDbContext()
            : base("FavLocs")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public static FavLocsDbContext Create()
        {
            return new FavLocsDbContext();
        }

        IDbSet<T> IFavLocsDbContext.Set<T>()
        {
            return this.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
