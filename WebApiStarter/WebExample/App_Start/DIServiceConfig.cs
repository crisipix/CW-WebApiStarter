using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace WebExample.App_Start
{
    public class DIServiceConfig
    {
        private static IContainer Container { get; set; }
        protected static string ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public static void Register() {
            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Create your builder.
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            AutoFacServiceConfig.RegisterServices(builder);
            builder.Register(c => new SqlConnection(ConnectionString)).As<IDbConnection>().InstancePerLifetimeScope();

            // Set the dependency resolver to be Autofac.
            Container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }

    }
}