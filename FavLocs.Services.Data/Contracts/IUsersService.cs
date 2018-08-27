using FavLocs.Models;

namespace FavLocs.Services.Data.Contracts
{
    public interface IUsersService
    {
        void AddLocationToFavorites(int locationId, string likerId);
        void RemoveLocationFromFavorites(int locationId, string likerId);
    }
}
