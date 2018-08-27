using FavLocs.App_Start;
using FavLocs.Data;
using FavLocs.Data.Migrations;
using Microsoft.Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Data.Entity;
using System.Web.Http;

[assembly: OwinStartup(typeof(FavLocs.Startup))]

namespace FavLocs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FavLocsDbContext, Configuration>());

            // Automapper
            // ODataConfig

            var httpConfig = new HttpConfiguration();

            WebApiConfig.Register(httpConfig);

            ConfigureAuth(app);

            app
                .UseNinjectMiddleware(NinjectConfig.CreateKernel)
                .UseNinjectWebApi(httpConfig);
        }
    }
}
