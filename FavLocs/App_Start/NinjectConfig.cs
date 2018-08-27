using FavLocs.Data;
using FavLocs.Data.Contracts;
using FavLocs.Data.Repositories;
using FavLocs.Services.Data;
using FavLocs.Services.Data.Contracts;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Web;

namespace FavLocs.App_Start
{
    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IEFRepository<>)).To(typeof(EFRepository<>)).InRequestScope();
            kernel.Bind<IFavLocsDbContext>().To<FavLocsDbContext>().InRequestScope();
            kernel.Bind<IFavLocsData>().To<FavLocsData>().InRequestScope();
            kernel.Bind<ILocationsService>().To<LocationsService>().InRequestScope();
            kernel.Bind<IUsersService>().To<UsersService>().InRequestScope();
            kernel.Bind<ICountriesService>().To<CountriesService>().InRequestScope();
            kernel.Bind<IImageService>().To<ImageService>().InRequestScope();

        }
    }
}