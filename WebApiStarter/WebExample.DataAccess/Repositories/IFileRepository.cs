using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExample.DataAccess.Repositories;
using WebExample.DataAccess.Repositories.Dos;

namespace WebExample.DataAccess.Repositories
{
    public interface IFileRepository : IBaseRepository<FileDo>
    {
        Task<FileDo> Upload(FileDo file);
    }
}
