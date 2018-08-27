using FavLocs.Data.Contracts;
using FavLocs.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using FavLocs.Models;
using System.Linq;
using FavLocs.Services.Data.DataModels;

namespace FavLocs.Services.Data
{
    public class CountriesService : ICountriesService
    {
        private IFavLocsData data;
        public CountriesService(IFavLocsData data)
        {
            if(data == null)
            {
                throw new ArgumentNullException("The data cannot be null");
            }

            this.data = data;
        }

        //public IQueryable<Country> GetAllCountries()
        //{
        //    return this.data.Countries.All;
        //}
        public IEnumerable<CountryDataModel> GetAllCountries()
        {
            return this.data.Countries.All.Select(CountryDataModel.FromCountry).ToList();
        }
    }
}
