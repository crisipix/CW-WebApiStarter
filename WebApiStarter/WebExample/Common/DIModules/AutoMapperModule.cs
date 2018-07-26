using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExample.DataAccess.Mappers;

namespace WebExample.Common.DIModules
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //register all profile classes in the calling assembly
            builder.RegisterAssemblyTypes(typeof(AutoMapperModule).Assembly).As<Profile>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                // Load in all our AutoMapper profiles that have been registered
                foreach (var profile in context.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
                cfg.AddProfile(typeof(DataObjectProfile));
                cfg.AddProfile(typeof(ModelMapperProfile));
            }))
            .AsSelf()
            .SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                    .As<IMapper>()
                    .InstancePerLifetimeScope();
        }
    }
}