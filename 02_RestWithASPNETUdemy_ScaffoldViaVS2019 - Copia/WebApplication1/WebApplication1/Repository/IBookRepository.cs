using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book Update(Book book);
        Book FindById(long id);
        void Delete(long id);
        List<Book> FindAll();
        bool Exists(long id);
    }
}
