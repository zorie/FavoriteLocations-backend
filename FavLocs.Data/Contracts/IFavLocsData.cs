using FavLocs.Data.Repositories;
using FavLocs.Models;

namespace FavLocs.Data.Contracts
{
    public interface IFavLocsData
    {
        IEFRepository<User> Users { get; }
        IEFRepository<Location> Locations { get; }
        IEFRepository<Country> Countries { get; }
        int SaveChanges();
    }
}
