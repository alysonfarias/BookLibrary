using System.Collections.Generic;
using WebApplication1.Data.VO;

namespace WebApplication1.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindByName(string firstName, string lastName);

        void Delete(long id);
        PersonVO Disable(long id);

        List<PersonVO> FindAll();

    }
}
