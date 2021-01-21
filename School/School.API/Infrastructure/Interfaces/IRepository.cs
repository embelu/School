using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Infrastructure.Repositories
{
    public interface IRepository <TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll();
        public TEntity GetById(int id);
        public int Post(TEntity entity);
        public TEntity Put(TEntity entity);
        public int Delete(TEntity entity);
    }
}
