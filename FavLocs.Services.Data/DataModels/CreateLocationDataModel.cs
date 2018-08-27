using FavLocs.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FavLocs.Services.Data.DataModels
{
    public class CreateLocationDataModel
    {
        public static Expression<Func<CreateLocationDataModel, Location>> FromCreateLocation(string userName)
        {
            return createLocation => new Location
            {
                Author = userName,
                DateCreated = DateTime.Now,
                Name = createLocation.Name,
                CountryId = createLocation.CountryId,
                Description = createLocation.Description,
                PhotoUrl = createLocation.PhotoUrl,
                UsersWhoLikedThis = new HashSet<User>()
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int CountryId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
