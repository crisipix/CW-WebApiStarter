using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Repositories;
using $safeprojectname$.Repositories.Dos;

namespace $safeprojectname$.Repositories
{
    public interface IFileRepository : IBaseRepository<FileDo>
    {
        Task<FileDo> Upload(FileDo file);
    }
}
