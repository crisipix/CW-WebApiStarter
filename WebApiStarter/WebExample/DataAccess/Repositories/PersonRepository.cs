using Dapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebExample.DataAccess.Dos;

namespace WebExample.DataAccess.Repositories
{
    public class PersonRepository : BaseRepository<PersonDo>
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PersonRepository()
        {
        }

        public override IEnumerable<PersonDo> GetAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<PersonDo>("SELECT * FROM [dbo].[Person]").ToList();
            }
        }

        public override PersonDo Get(int Id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<PersonDo>("SELECT * FROM [dbo].[Person] WHERE Id = @Id", new { Id }).FirstOrDefault();
            }
        }

        public override PersonDo Insert(PersonDo p)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = @" INSERT INTO [dbo].[Person] (Name, Age)VALUES
                            (@Name, @Age) 
                            SELECT Id, Name, Age FROM [dbo].[Person] where Id = SCOPE_IDENTITY()";
                 var result = db.Query<PersonDo>(sqlQuery, p).FirstOrDefault();
                return result;
            }
        }

        public override PersonDo Update(PersonDo p)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {

                string sqlQuery = @"UPDATE p SET p.Name = @Name, p.Age = @Age FROM [dbo].[Person] p WHERE p.Id = @Id
                                    SELECT Id, Name, Age FROM [dbo].[Person] where Id =@Id";
                var result = db.Query<PersonDo>(sqlQuery, p).FirstOrDefault();
                return result;               

            }

        }

        public override bool Delete(int Id)
        {
            try {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {

                    string sqlQuery = @"DELETE p FROM [dbo].[Person] p WHERE p.Id = @Id";
                    db.Execute(sqlQuery, new { Id });
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }
    }
}