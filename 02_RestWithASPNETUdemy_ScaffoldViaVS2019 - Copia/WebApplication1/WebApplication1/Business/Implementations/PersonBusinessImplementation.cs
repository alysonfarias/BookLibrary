using System.Collections.Generic;
using WebApplication1.Data.Converter.Implementations;
using WebApplication1.Data.VO;
using WebApplication1.Model;
using WebApplication1.Repository.Generic;

namespace WebApplication1.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person>  _repository;
        private readonly PersonConverter _converter;
        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        // Method responsible for get all the people
        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
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
    }
}
