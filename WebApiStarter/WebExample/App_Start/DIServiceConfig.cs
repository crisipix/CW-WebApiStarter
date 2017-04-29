using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace WebExample.App_Start
{
    public class DIServiceConfig
    {
        private static IContainer Container { get; set; }

        public static void Register() {
            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Create your builder.
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            AutoFacServiceConfig.RegisterServices(builder);
            
            // Set the dependency resolver to be Autofac.
            Container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }

    }
}