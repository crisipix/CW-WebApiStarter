using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebExample.App_Start;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace WebExample
{
    
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DIServiceConfig.Register();

            //SwaggerConfig.Register(GlobalConfiguration.Configuration);
            /*
             httpConfiguration
     .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
     .EnableSwaggerUi();
             */
        }
    }
}
