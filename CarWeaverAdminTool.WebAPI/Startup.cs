using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


[assembly: OwinStartup(typeof(CarWeaverAdminTool.WebAPI.Startup))]
namespace CarWeaverAdminTool.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Configure Bearer Authentication
            ConfigureAuth(app);

            HttpConfiguration config = new HttpConfiguration();

            //Configure AutoFac (http://autofac.org/) for DependencyResolver
            ConfigureComposition(config);

            //Configure WebApi
            ConfigureWebApi(config);
            app.UseWebApi(config);
        }
    }
}