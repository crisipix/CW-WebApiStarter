using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExample.DataAccess.Models;

namespace WebExample.DataAccess.Services.File
{
    public interface IFileService 
    {
        Task<FileModel> Upload(FileModel file);

    }
}
