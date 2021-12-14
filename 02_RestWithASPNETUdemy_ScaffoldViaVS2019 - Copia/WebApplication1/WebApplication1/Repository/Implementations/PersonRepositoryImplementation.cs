using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Business.Implementations;
using WebApplication1.Model;
using WebApplication1.Model.Context;
using WebApplication1.Repository;

namespace WebApplication1.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySQLContext _context;
        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }
        // Method responsible for get all the people
        public List<Person> FindAll()
        {
            return _context.People.ToList();
        }

        // Method responsible for get a specify person from an Id
        public Person FindById(long id)
        {
            return _context.People.SingleOrDefault(p => p.Id.Equals(id));
        }

        // Method responsible for create a new person
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        // Method responsible for delete a person from an Id
        public void Delete(long id)
        {
            var result = _context.People.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.People.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }


        }

        // Method responsible for update person data
        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var result = _context.People.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return person;

        }

        // Method responsible for check if a person exists from an Id
        public bool Exists(long id)
        {
            return _context.People.Any(p => p.Id.Equals(id));
        }


    }
}
