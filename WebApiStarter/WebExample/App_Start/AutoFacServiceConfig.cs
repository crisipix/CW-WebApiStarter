using Autofac;
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
using WebExample.DataAccess.Services.Post;
using WebExample.DataAccess.Services.Store;

namespace WebExample.App_Start
{
    public class AutoFacServiceConfig
    {
        public static void RegisterServices(ContainerBuilder builder) {
            // Module Registrations for log4net and AutoMapper
            builder.RegisterModule(new LoggingModule());
            builder.RegisterModule(new AutoMapperModule());
        }
    }
}