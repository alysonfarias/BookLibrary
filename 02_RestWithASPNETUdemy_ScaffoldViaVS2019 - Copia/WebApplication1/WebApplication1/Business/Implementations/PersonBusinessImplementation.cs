using System.Collections.Generic;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }
        // Method responsible for get all the people
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        // Method responsible for get a specify person from an Id
        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        // Method responsible for create a new person
        public Person Create(Person person)
        {
            
            return _repository.Create(person);
        }

        // Method responsible for delete a person from an Id
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        // Method responsible for update person data
        public Person Update(Person person)
        {

           return _repository.Update(person);

        }
    }
}
