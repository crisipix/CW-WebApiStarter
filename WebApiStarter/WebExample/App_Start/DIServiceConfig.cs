using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using WebExample.DataAccess.Dos;
using WebExample.DataAccess.Repositories;
using WebExample.Services.Account;
using WebExample.Services.Person;

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
            // http://stackoverflow.com/questions/15226536/register-generic-type-with-autofac
            // via its interface:
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<PersonService>().As<IPersonService>();
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();
            //builder.RegisterGeneric(typeof(BaseRepository<>)).AsSelf();
            builder.RegisterType<PersonRepository>().As<BaseRepository<PersonDo>>();



            //builder.RegisterType<PersonRepository>().As<IBaseRepository>();


            // However, if you want BOTH services (not as common)
            // you can say so:
            //builder.RegisterType<IAccountService>().AsSelf().As<IService>();

            // Set the dependency resolver to be Autofac.
            Container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }

    }
}