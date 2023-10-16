using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior.one.Inharitance.Repository
{
    public interface IGenenricRepository<T>
    {
        void Create(T entity);
    }
}
