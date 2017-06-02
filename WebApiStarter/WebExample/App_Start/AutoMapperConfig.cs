using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExample.DataAccess.Repositories.Dos;
using WebExample.DataAccess.Models;

namespace WebExample.App_Start
{
    
    public class AutoMapperConfig
    {
        /// <summary>
        /// Not used anymore, if you are going to use DI use the Automapper Module to 
        /// load into AutoFac
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<PersonDo, PersonModel>().ReverseMap();

                config.CreateMap<AccountDo, AccountModel>()
                        .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.Code));

      

                //config.CreateMap<AccountDo, AccountModel>()
                //    .ForMember(dest => dest.Owner.Id, opts => opts.MapFrom(src => src.OwnerId));
            });
        }
    }
}