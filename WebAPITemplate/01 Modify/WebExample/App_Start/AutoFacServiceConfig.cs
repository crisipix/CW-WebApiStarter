using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using $safeprojectname$.DataAccess.Repositories.Dos;
using $safeprojectname$.DataAccess.Repositories;
using $safeprojectname$.DataAccess.Services.Account;
using $safeprojectname$.DataAccess.Services.Person;
using $safeprojectname$.Common.DIModules;
using $safeprojectname$.DataAccess.Common;
using $safeprojectname$.DataAccess.Services.Post;
using $safeprojectname$.DataAccess.Services.Store;

namespace $safeprojectname$.App_Start
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