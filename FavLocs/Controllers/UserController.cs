using FavLocs.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace FavLocs.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUsersService usersService;

        public UserController(IUsersService usersService)
        {
            if(usersService == null)
            {
                throw new ArgumentNullException("users service");
            }

            this.usersService = usersService;
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult FavoriteLocation(string id)
        {
            int locationId = int.Parse(id);
            string likerId = this.User.Identity.GetUserId();

            usersService.AddLocationToFavorites(locationId, likerId);

            return Ok("successssssss");
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult UnfavoriteLocation(string id)
        {
            int locationId = int.Parse(id);
            string unlikerId = this.User.Identity.GetUserId();

            usersService.RemoveLocationFromFavorites(locationId, unlikerId);

            return Ok("Successfully removed from favorites list");
        }
    }
}
