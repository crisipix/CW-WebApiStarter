using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExample.DataAccess.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int Id);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(int id);
    }
}
