using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExample.DataAccess.Models;
using WebExample.DataAccess.Repositories.Dos;

namespace WebExample.DataAccess.Mappers
{
    public class DataObjectProfile : Profile
    {
        public DataObjectProfile()
        {
            var accountDoMapper = CreateMap<AccountModel, AccountDo>();
           accountDoMapper.ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.Owner.Id));

            var personDoMapper = CreateMap<PersonModel, PersonDo>();
            //personDoMapper.ForMember(dest => dest, opt => opt.Ignore());
        }
    }
}
