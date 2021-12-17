using System.Collections.Generic;
using WebApplication1.Model;

namespace WebApplication1.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book Update(Book book);
        Book FindById(long id);
        void Delete(long id);

        List<Book> FindAll();
    }
}
