using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExample.DataAccess.Models;
using WebExample.DataAccess.Repositories.Dos;

namespace WebExample.Common.Profiles
{
    /// <summary>
    /// This profile should be automatically picked up by the AutoMapperModule
    /// reflection lookup. 
    /// the DataObjectMapper profile needs to be added manually.
    /// Unless a AutoMapperModule is added per project and registerd in the DIService AutoFacServiceConfig 
    /// class. 
    /// </summary>
    public class ModelMapperProfile : Profile
    {
        public ModelMapperProfile()
        {
            var personMapper = CreateMap<PersonDo, PersonModel>();
            personMapper.ForMember(dest => dest.CanVote, opt => opt.ResolveUsing(p => p.Age >= 18));
            CreateMap<AccountDo, AccountModel>();
            CreateMap<StoreDo, StoreModel>();
            CreateMap<FileDo, FileModel>();

        }
    }
}