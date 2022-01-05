using System.Collections.Generic;
using WebApplication1.Data.VO;
using WebApplication1.Hypermedia.Utils;

namespace WebApplication1.Business
{
  public interface IPersonBusiness
  {
    PersonVO Create(PersonVO person);
    PersonVO Update(PersonVO person);
    PersonVO FindById(long id);
    List<PersonVO> FindByName(string firstName, string lastName);

    PagedSearchVO<PersonVO> FindWithPagedSearch (
      string name, string sortDirection,
      int pageSize, int page);


    void Delete(long id);
    PersonVO Disable(long id);

    List<PersonVO> FindAll();

  }
}
