using FavLocs.Data.Contracts;
using FavLocs.Models;
using FavLocs.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavLocs.Services.Data
{
    public class ImageService : IImageService
    {
        private readonly IFavLocsData data;
        public ImageService(IFavLocsData data)
        {
            if(data == null)
            {
                throw new ArgumentNullException("Data cannot be null");
            }

            this.data = data;
        }

        public void UploadImageOfLocationWithId(int id, string photoUrl)
        {
            Location locationWithImage = this.data.Locations.GetById(id);

            locationWithImage.PhotoUrl = photoUrl;
            this.data.Locations.Update(locationWithImage);
            this.data.SaveChanges();
        }
    }
}
