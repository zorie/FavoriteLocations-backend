using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavLocs.Services.Data.Contracts
{
    public interface IImageService
    {
        void UploadImageOfLocationWithId(int id, string photoUrl);
    }
}
