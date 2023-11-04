//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Junior.one.Inharitance.Repository
//{
//    public interface IGenericRepository<T>
//    {
//        int Count { get; }

//        void Create(T entity);
//        IEnumerable<T> GetData();
//        void Remove(T entity);
//        void Clear();
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior.one.Inharitance.Repository
{
    public interface IGenericRepository<T>
    {
        void Create(T entity);
        IEnumerable<T> GetData();
    }
}
