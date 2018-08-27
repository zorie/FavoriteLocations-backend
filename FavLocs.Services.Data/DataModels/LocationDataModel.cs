using FavLocs.Models;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace FavLocs.Services.Data.DataModels
{
    public class LocationDataModel
    {
        public static Expression<Func<Location, LocationDataModel>> FromLocation(string userId)
        {
            return location => new LocationDataModel
            {
                Id = location.Id,
                Name = location.Name,
                Country = location.Country.Name,
                PhotoUrl = location.PhotoUrl,
                Description = location.Description,
                NumberOfLikes = location.UsersWhoLikedThis.Count,
                isLikedByCurrentUser = location.UsersWhoLikedThis.Any(u => u.Id == userId)
            };            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }

        public int NumberOfLikes { get; set; }
        public bool isLikedByCurrentUser { get; set; }

    }
}
