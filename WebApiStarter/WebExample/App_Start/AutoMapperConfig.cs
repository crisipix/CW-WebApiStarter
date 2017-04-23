﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExample.DataAccess.Dos;
using WebExample.Models;

namespace WebExample.App_Start
{
    
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<PersonDo, PersonModel>().ReverseMap();
                config.CreateMap<AccountDo, AccountModel>();
                config.CreateMap<AccountModel, AccountDo>()
                      .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.Owner.Id));

                //config.CreateMap<AccountDo, AccountModel>()
                //    .ForMember(dest => dest.Owner.Id, opts => opts.MapFrom(src => src.OwnerId));
            });
        }
    }
}