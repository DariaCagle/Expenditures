using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity, Tkey> where TEntity : class, ITEntity<Tkey>
    {
        TEntity Create(TEntity model);
        TEntity GetBy(Func<TEntity, bool> func);
        IEnumerable<TEntity> GetAll();
        void Remove(TEntity model);
        void Update(TEntity model);
        TEntity GetById(Tkey id);

    }
}
