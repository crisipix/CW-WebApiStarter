using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using $safeprojectname$.Repositories;

namespace $safeprojectname$.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected string ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public virtual IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Get(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}