using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPHW6.Domain
{
    public interface IRepository<T, ID>
    {
        T Save(T entity);
        IEnumerable<T> GetAll();
        T Get(ID id);
        IEnumerable<T> GetBy(Func<T, bool> predicate);
        bool Remove(Guid id);
        T Update(T entity);
    }
}
