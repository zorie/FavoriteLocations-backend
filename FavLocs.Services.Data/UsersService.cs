using FavLocs.Data.Contracts;
using FavLocs.Models;
using FavLocs.Services.Data.Contracts;
using System;
using System.Data.Entity;
using System.Linq;

namespace FavLocs.Services.Data
{
    public class UsersService : IUsersService
    {
        private IFavLocsData data;
        public UsersService(IFavLocsData data)
        {
            if(data == null)
            {
                throw new ArgumentNullException("data");
            }

            this.data = data;
        }
        public void AddLocationToFavorites(int locationId, string likerId)
        {
            User user = data.Users.GetById(likerId);
            Location location = this.data.Locations.GetById(locationId);

            location.UsersWhoLikedThis.Add(user);
            data.Locations.Update(location);

            user.FavoriteLocations.Add(location);
            data.Users.Update(user);

            this.data.SaveChanges();
        }

        public void RemoveLocationFromFavorites(int locationId, string likerId)
        {
            User user = data.Users.All.Where(u => u.Id == likerId).Include(x => x.FavoriteLocations).FirstOrDefault();
            Location location = data.Locations.All.Where(l => l.Id == locationId).Include(x => x.UsersWhoLikedThis).FirstOrDefault();

            location.UsersWhoLikedThis.Remove(user);
            data.Locations.Update(location);

            user.FavoriteLocations.Remove(location);
            data.Users.Update(user);

            this.data.SaveChanges();
        }
    }
}
