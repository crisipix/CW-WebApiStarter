﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExample.DataAccess.Repositories.Dos;
using WebExample.DataAccess.Repositories;
using WebExample.DataAccess.Services.Account;
using WebExample.DataAccess.Services.Person;
using WebExample.Common.DIModules;
using WebExample.DataAccess.Common;

namespace WebExample.App_Start
{
    public class AutoFacServiceConfig
    {
        public static void RegisterServices(ContainerBuilder builder) {
            // Usually you're only interested in exposing the type
            // http://stackoverflow.com/questions/15226536/register-generic-type-with-autofac
            // via its interface:
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<PersonService>().As<IPersonService>();
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();

            //builder.RegisterGeneric(typeof(BaseRepository<>)).AsSelf();
            builder.RegisterType<PersonRepository>().As<BaseRepository<PersonDo>>();
            builder.RegisterType<AccountRepository>().As<BaseRepository<AccountDo>>();

            // Module Registrations
            builder.RegisterModule(new LoggingModule());
            builder.RegisterModule(new AutoMapperModule());

            //
            builder.RegisterType<HttpClientProvider>().As<IHttpClientProvider>();
            
            
            //builder.RegisterType<PersonRepository>().As<IBaseRepository>();
            // However, if you want BOTH services (not as common)
            // you can say so:
            //builder.RegisterType<IAccountService>().AsSelf().As<IService>();

        }
    }
}