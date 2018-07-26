using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Models;

namespace $safeprojectname$.Services.File
{
    public interface IFileService 
    {
        Task<FileModel> Upload(FileModel file);

    }
}
