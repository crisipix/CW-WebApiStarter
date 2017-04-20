using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebExample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //SwaggerConfig.Register(GlobalConfiguration.Configuration);
            /*
             httpConfiguration
     .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
     .EnableSwaggerUi();
             */
        }
    }
}
