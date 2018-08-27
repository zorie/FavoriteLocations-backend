using FavLocs.Services.Data.Contracts;
using Microsoft.AspNet.Identity;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace FavLocs.Controllers
{
    //[Route("api/images")]
    public class ImagesController : ApiController
    {
        private readonly IImageService imageService;
        public ImagesController(IImageService imageService)
        {
            if(imageService == null)
            {
                throw new ArgumentNullException("Image service cannot be null");
            }

            this.imageService = imageService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get(string name)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            string filePath = HostingEnvironment.MapPath(string.Format("~/Images/{0}", name));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                Image image = Image.FromStream(fs);
                MemoryStream memoryStream = new MemoryStream();
                image.Save(memoryStream, ImageFormat.Jpeg);
                response.Content = new ByteArrayContent(memoryStream.ToArray());
            }

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

            return response;
        }

        [Authorize]
        [HttpPost]
        public HttpResponseMessage UploadPhoto()
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK);

            string[] headersValues = System.Web.HttpContext.Current.Request.Headers.GetValues("LocationId");
            int locationId = int.Parse(headersValues[0]);
            string userName = this.User.Identity.GetUserName();
            int index = userName.IndexOf('@');
            string decentUsername = userName.Substring(0, index);

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                HttpPostedFile img = System.Web.HttpContext.Current.Request.Files["LocationImage"];
                string filePath = HostingEnvironment.MapPath("~/Images/");
                string dateNow = ((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString();
                string fileName = decentUsername + dateNow + ".jpg";

                string fullPath = Path.Combine(filePath, fileName);
                img.SaveAs(fullPath);

                imageService.UploadImageOfLocationWithId(locationId, fileName);
            }

            return result;
        }
    }
}
