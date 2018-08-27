using FavLocs.Models;
using System;
using System.Linq.Expressions;

namespace FavLocs.Services.Data.DataModels
{
    public class CountryDataModel
    {
        public static Expression<Func<Country, CountryDataModel>> FromCountry
        {
            get
            {
                return country => new CountryDataModel
                {
                    Id = country.Id,
                    Name = country.Name
                };
            }            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
