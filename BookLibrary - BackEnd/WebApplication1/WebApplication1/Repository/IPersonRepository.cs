using WebApplication1.Model;
using WebApplication1.Repository.Generic;

namespace WebApplication1.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}
