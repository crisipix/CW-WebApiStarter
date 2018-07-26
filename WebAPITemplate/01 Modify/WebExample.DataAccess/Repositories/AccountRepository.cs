using Dapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using $safeprojectname$.Repositories.Dos;

namespace $safeprojectname$.Repositories
{

    public class AccountRepository : BaseRepository<AccountDo>
    {
        // private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ILog _log;
        public AccountRepository(ILog log)
        {
            _log = log;
        }
        public override IEnumerable<AccountDo> GetAll()
        {
            _log.Debug("GET Accounts From DB");

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<AccountDo>("SELECT * FROM[dbo].[Account]").ToList();
            }
        }

        public override AccountDo Get(int Id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return  db.Query<AccountDo>("SELECT * FROM [dbo].[Account] WHERE Id = @Id", new { Id }).FirstOrDefault();                
            }
        }

        public override AccountDo Insert(AccountDo account)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = @" INSERT INTO [dbo].[Account] (Code, OwnerId)VALUES
                             (@Code, @OwnerId) 
                            SELECT Id, Code, OwnerId FROM [dbo].[Account] where Id = SCOPE_IDENTITY()";
                var result = db.Query<AccountDo>(sqlQuery, account).FirstOrDefault();
                return result;
            }
        }

        public override AccountDo Update(AccountDo account)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string sqlQuery = @"UPDATE a SET a.Code = @Code, a.OwnerId = @OwnerId FROM [dbo].[Account] a WHERE a.Id = @Id
                                    SELECT Id, Code, OwnerId FROM [dbo].[Account] where Id =@Id";
                var result = db.Query<AccountDo>(sqlQuery, account).FirstOrDefault();
                return result;
            }
        }

        public override bool Delete(int Id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {

                    string sqlQuery = @"DELETE a FROM [dbo].[Account] a WHERE a.Id = @Id";
                    db.Execute(sqlQuery, new { Id });
                    return true;
                }
            }
            catch (Exception e)
            {
                _log.Error(e);
                return false;
            }
        }
    }

}