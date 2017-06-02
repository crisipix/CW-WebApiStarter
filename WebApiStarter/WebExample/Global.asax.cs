using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebExample.App_Start;
using WebExample.Common.MessageHandlers;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace WebExample
{
    
    public class WebApiApplication : System.Web.HttpApplication
    {
        /*
         Swagger auto registers
             */
        protected void Application_Start()
        {
           // AutoMapperConfig.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DIServiceConfig.Register();
            GlobalConfiguration.Configuration.MessageHandlers.Add(new MessageLoggingHandler());

            //SwaggerConfig.Register(GlobalConfiguration.Configuration);
            /*
             httpConfiguration
             .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
             .EnableSwaggerUi();
             */
        }
    }
}
