using System.Web.Http;
using Swashbuckle.Application;

namespace CarWeaverAdminTool.WebAPI
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "CarWeaverAdminTool.WebAPI");
            })
            .EnableSwaggerUi(c =>
            {
            });
        }
    }
}
