using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using WebExample.Services.Account;

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

           

            // Usually you're only interested in exposing the type
            // via its interface:
            builder.RegisterType<AccountService>().As<IAccountService>();
            // However, if you want BOTH services (not as common)
            // you can say so:
            //builder.RegisterType<IAccountService>().AsSelf().As<IService>();

            // Set the dependency resolver to be Autofac.
            Container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }

    }
}