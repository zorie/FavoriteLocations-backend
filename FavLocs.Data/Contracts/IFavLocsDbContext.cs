using FavLocs.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace FavLocs.Data.Contracts
{
    public interface IFavLocsDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Location> Locations { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
