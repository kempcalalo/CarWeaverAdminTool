using Autofac;
using System.Web.Http;
using CarWeaverAdminTool.WebAPI.Identity;
using CarWeaverAdminTool.WebAPI.Extensions;
using System.Configuration;

namespace CarWeaverAdminTool.WebAPI
{
	public partial class Startup
	{
        public static void ConfigureComposition(HttpConfiguration config)
        {
            IContainer container = RegisterServices();
            config.DependencyResolver = new AutoFacDependencyResolver(container);
        }
        private static IContainer RegisterServices()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .Where(t => t.Name.EndsWith("Controller"))
                .AsSelf();

            builder.RegisterInstance(new DomainUserLogInProvider(ConfigurationManager.AppSettings["DomainName"]))
                .As<ILoginProvider>()
                .SingleInstance();

            return builder.Build();
        }
    }
}