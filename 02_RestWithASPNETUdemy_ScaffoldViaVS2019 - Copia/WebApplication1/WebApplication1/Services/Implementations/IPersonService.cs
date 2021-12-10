using System.Collections.Generic;
using WebApplication1.Model;

namespace WebApplication1.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person Update(Person person);
        Person FindById(long id);
        void Delete(long id);

        List<Person> FindAll();
    }
}
