using Dapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Repositories.Dos;

namespace $safeprojectname$.Repositories
{
    public class FileRepository : BaseRepository<FileDo>, IFileRepository
    {

        private readonly ILog _log;
        public FileRepository(ILog log)
        {
            _log = log;
        }

        public async Task<FileDo> Upload(FileDo file)
        {
            _log.Debug("GET upload to DB");

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                /*
                    [Id] [int] IDENTITY(1,1) NOT NULL,
	                [Size] [int] NOT NULL,
	                [Contents] [varchar](MAX) NOT NULL,
	                [FileName] [varchar](100) NOT NULL,
	                [FileType] [varchar](100) NOT NULL
                 */

                var sqlQuery = @" INSERT INTO [dbo].[File] (Size, Contents, FileName, FileType)VALUES
                             (@Size, @Contents, @FileName, @FileType) 
                            SELECT * FROM [dbo].[File] where Id = SCOPE_IDENTITY()";

                var result = db.Query<FileDo>(sqlQuery, new { Size = file.Size, Contents = file.Contents, FileName = file.FileName, FileType = file.FileType}).FirstOrDefault();

                return result;
            }
        }
    }
}
