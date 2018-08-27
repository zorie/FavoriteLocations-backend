using FavLocs.Data.Contracts;
using FavLocs.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using FavLocs.Services.Data.DataModels;
using FavLocs.Models;

namespace FavLocs.Services.Data
{
    public class LocationsService : ILocationsService
    {
        private readonly IFavLocsData data;
        public LocationsService(IFavLocsData data)
        {
            if(data == null)
            {
                throw new ArgumentNullException("Data cannot be null");
            }

            this.data = data;
        }

        public LocationDataModel GetLocationById(int id, string possibleLoggedInUserId)
        {
            LocationDataModel location = this.data.Locations
                .All
                .Where(x => x.Id == id)
                .Select(LocationDataModel.FromLocation(possibleLoggedInUserId))
                .FirstOrDefault();

            return location;
        }

        public IEnumerable<LocationDataModel> GetLocations(string possibleLoggedInUserId)
        {
            var locations = this.data.Locations
                .All
                .Select(LocationDataModel.FromLocation(possibleLoggedInUserId)).ToList();

            return locations;
        }

        public CreateLocationDataModel CreateLocation(CreateLocationDataModel model, string userName)
        {
            Location newLocation = new Location
            {
                Author = userName,
                DateCreated = DateTime.Now,
                Name = model.Name,
                CountryId = model.CountryId,
                Description = model.Description,
                PhotoUrl = model.PhotoUrl,
                UsersWhoLikedThis = new HashSet<User>()
            };

            this.data.Locations.Add(newLocation);
            this.data.SaveChanges();

            model.Id = newLocation.Id;
            model.DateCreated = newLocation.DateCreated;

            return model;
        }
    }
}
