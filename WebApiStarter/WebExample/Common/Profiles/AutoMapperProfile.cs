using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExample.DataAccess.Models;
using WebExample.DataAccess.Repositories.Dos;

namespace WebExample.Common.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PersonDo, PersonModel>();
            CreateMap<AccountDo, AccountModel>();
            CreateMap<AccountModel, AccountDo>()
                    .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.Owner.Id));
        }
    }
}