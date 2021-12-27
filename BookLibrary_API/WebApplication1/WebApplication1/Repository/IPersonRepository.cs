using System.Collections.Generic;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person Update(Person person);
        Person FindById(long id);
        void Delete(long id);
        List<Person> FindAll();
        bool Exists(long id);
    }
}
