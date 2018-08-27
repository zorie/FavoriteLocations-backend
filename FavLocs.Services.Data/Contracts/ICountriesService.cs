using FavLocs.Models;
using FavLocs.Services.Data.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace FavLocs.Services.Data.Contracts
{
    public interface ICountriesService
    {
        IEnumerable<CountryDataModel> GetAllCountries();
    }
}
