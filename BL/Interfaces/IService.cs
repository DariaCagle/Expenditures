using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IService<T>
    { 
        IEnumerable<T> GetAll();
        T Create(T model);
        void Update(T model);
        T GetById(int id);
        void Remove(T model);
        T GetBy(Expression<Func<T, bool>> condition);
    }
}
