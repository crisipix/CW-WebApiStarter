using Dapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Repositories.Dos;

namespace $safeprojectname$.Repositories
{
    public class StoreRepository : BaseRepository<StoreDo>
    {
        private readonly ILog _log;
        private readonly IDbConnection _connection;
        public StoreRepository(IDbConnection connection,
            ILog log)
        {
            _log = log;
            _connection = connection;
        }

        public override IEnumerable<StoreDo> GetAll()
        {
            return _connection.Query<StoreDo>("SELECT * FROM [dbo].[Store]").ToList();
        }

        public override StoreDo Get(int Id)
        {
            return _connection.Query<StoreDo>("SELECT * FROM [dbo].[Store] WHERE Id = @Id", new { Id }).FirstOrDefault();
        }

        public override StoreDo Insert(StoreDo p)
        {

            var sqlQuery = @" INSERT INTO [dbo].[Store] (Code)VALUES
                            (@Code) 
                            SELECT Id, Code FROM [dbo].[Store] where Id = SCOPE_IDENTITY()";
            var result = _connection.Query<StoreDo>(sqlQuery, p).FirstOrDefault();
            return result;

        }

        public override StoreDo Update(StoreDo p)
        {           
                string sqlQuery = @"UPDATE p SET p.Code = @Code FROM [dbo].[Store] p WHERE p.Id = @Id
                                    SELECT Id, Code FROM [dbo].[Store] where Id =@Id";
                var result = _connection.Query<StoreDo>(sqlQuery, p).FirstOrDefault();
                return result;
 
        }
    }
}
