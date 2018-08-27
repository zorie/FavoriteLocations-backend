using FavLocs.Services.Data.Contracts;
using FavLocs.Services.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.Identity;


namespace FavLocs.Controllers
{
    public class LocationsController : ApiController
    {
        private readonly ILocationsService locationsService;
        public LocationsController(ILocationsService locationsService)
        {
            if(locationsService == null)
            {
                throw new ArgumentNullException("Locations service cannot be null");
            }

            this.locationsService = locationsService;
        }

        [HttpGet]
        //[Authorize]
        public IHttpActionResult All()
        {
            string possibleLoggedInUserId = this.User.Identity.GetUserId();

            IEnumerable<LocationDataModel> locs =  this.locationsService.GetLocations(possibleLoggedInUserId);

            return Ok(locs);
        }

        [HttpGet]
        public IHttpActionResult GetLocationDetails(string id)
        {
            int locationId = int.Parse(id);
            string possibleLoggedInUserId = this.User.Identity.GetUserId();


            LocationDataModel location = this.locationsService.GetLocationById(locationId, possibleLoggedInUserId);

            return Ok(location);
        }

        [HttpPost]
        public IHttpActionResult Create(CreateLocationDataModel newLocation)
        {
            string userName = this.User.Identity.GetUserName();
            
            CreateLocationDataModel addedLocation = this.locationsService.CreateLocation(newLocation, userName);
            return Ok(addedLocation);
        }
    }
}
