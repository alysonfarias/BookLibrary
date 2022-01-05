using System.Collections.Generic;
using WebApplication1.Data.Converter.Implementations;
using WebApplication1.Data.VO;
using WebApplication1.Hypermedia.Utils;
using WebApplication1.Model;
using WebApplication1.Repository;
using WebApplication1.Repository.Generic;

namespace WebApplication1.Business.Implementations
{
  public class PersonBusinessImplementation : IPersonBusiness
  {
    private readonly IPersonRepository _repository;
    private readonly PersonConverter _converter;
    public PersonBusinessImplementation(IPersonRepository repository)
    {
      _repository = repository;
      _converter = new PersonConverter();
    }
    // Method responsible for get all the people
    public List<PersonVO> FindAll()
    {
      return _converter.Parse(_repository.FindAll());
    }

    public PagedSearchVO<PersonVO> FindWithPagedSearch(
      string name, string sortDirection, int pageSize, int page)
    {
      var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("asc") ?  "desc" : "asc";
      var size = (pageSize < 1) ? 1 : pageSize;
      var offset = page > 0 ? (page - 1) * size : 0;

      string query = @"SELECT * FROM person p WHERE 1 = 1";
      if (!string.IsNullOrWhiteSpace(name)) query = query + $" AND p.first_name LIKE '%{name}%' ";
      query += $" ORDER BY p.first_name {sort} LIMIT {size} OFFSET {offset}";


      string countQuery = @"SELECT  count(*) FROM person p WHERE 1 = 1";
      if (!string.IsNullOrWhiteSpace(name)) countQuery = countQuery + $" AND  p.first_name LIKE '%{name}%'";

      var persons = _repository.FindWithPagedSearch(query);
      int totalResults = _repository.GetCount(countQuery);
      return new PagedSearchVO<PersonVO> {
        CurrentPage = page,
        List = _converter.Parse(persons),
        PageSize = size,
        SortedDirections = sort,
        TotalResults = totalResults
      };
    }

    // Method responsible for get a specify person from an Id
    public PersonVO FindById(long id)
    {
      return _converter.Parse(_repository.FindById(id));
    }

    // Method responsible for create a new person
    public PersonVO Create(PersonVO person)
    {
      var personEntity = _converter.Parse(person);
      personEntity = _repository.Create(personEntity);
      return _converter.Parse(personEntity);
    }

    // Method responsible for disable a person from an Id
    public PersonVO Disable(long id)
    {
      var personEntity = _repository.Disable(id);
      return _converter.Parse(personEntity);
    }

    // Method responsible for delete a person from an Id
    public void Delete(long id)
    {
      _repository.Delete(id);
    }


    // Method responsible for update person data
    public PersonVO Update(PersonVO person)
    {
      var personEntity = _converter.Parse(person);
      personEntity = _repository.Update(personEntity);
      return _converter.Parse(personEntity);
    }

    public List<PersonVO> FindByName(string firstName, string lastName)
    {
      return _converter.Parse(_repository.findByName(firstName, lastName));
    }


  }
}
