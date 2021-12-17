using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.Base;

namespace WebApplication1.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        T FindById(long id);
        void Delete(long id);
        List<T> FindAll();
        bool Exists(long id);
    }
}
