using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity, Tkey> where TEntity : class, ITEntity<Tkey>
    {
        TEntity Create(TEntity model);
        TEntity GetBy(Expression<Func<TEntity, bool>> condition);
        IEnumerable<TEntity> GetAll();
        void Remove(TEntity model);
        void Update(TEntity model);
        TEntity GetById(Tkey id);

    }
}
