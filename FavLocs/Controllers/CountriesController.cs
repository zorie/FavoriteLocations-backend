using FavLocs.Services.Data.Contracts;
using System;
using System.Web.Http;

namespace FavLocs.Controllers
{
    public class CountriesController : ApiController
    {
        private ICountriesService countriesService;
        public CountriesController(ICountriesService countriesService)
        {
            if(countriesService == null)
            {
                throw new ArgumentNullException("Country service cannot be null");
            }

            this.countriesService = countriesService;
        }

        //[HttpGet]
        //public IHttpActionResult GetAll()
        //{
        //    var countries = this.countriesService.GetAllCountries().ToList();

        //    return Ok(countries);
        //}

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var countries = this.countriesService.GetAllCountries();

            return Ok(countries);
        }
    }
}
