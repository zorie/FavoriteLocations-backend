using FavLocs.Models;
using FavLocs.Services.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavLocs.Services.Data.Contracts
{
    public interface ILocationsService
    {
        LocationDataModel GetLocationById(int id, string possibleLoggedInUserId);

        IEnumerable<LocationDataModel> GetLocations(string possibleLoggedInUserId);
        CreateLocationDataModel CreateLocation(CreateLocationDataModel location, string userName);

    }
}
