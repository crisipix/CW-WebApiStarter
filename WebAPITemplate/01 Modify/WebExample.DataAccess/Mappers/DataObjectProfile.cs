using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Models;
using $safeprojectname$.Repositories.Dos;

namespace $safeprojectname$.Mappers
{
    /// <summary>
    /// This DataObjectMapper profile needs to be added manually by type or instance within 
    /// the AutoMapperModule.
    /// Unless a AutoMapperModule is added per project and registerd in the DIService AutoFacServiceConfig 
    /// class. So creata  DataAccessAutoMapperModule and register in the DIModule
    /// </summary>
    public class DataObjectProfile : Profile
    {
        public DataObjectProfile()
        {
            var accountDoMapper = CreateMap<AccountModel, AccountDo>();
           accountDoMapper.ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.Owner.Id));

            var personDoMapper = CreateMap<PersonModel, PersonDo>();
            //personDoMapper.ForMember(dest => dest, opt => opt.Ignore());

            var storeDoMapper = CreateMap<StoreModel, StoreDo>();
            var fileDoMapper = CreateMap<FileModel, FileDo>();

        }
    }
}
