using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }
            return people;
        }

        private Person MockPerson(int i)
        {
            //if(i % 2  == 0)
            //{
            //    return new Person
            //    {
            //        Id = IncrementAndGet(),
            //        FirstName = "RandomName" + i,
            //        LastName = "RandomLastName" + i,
            //        Address = "RandomAddress, , Ontario - CA" + i,
            //        Gender = "Male"

            //    };
            //}
            //else
            //{
            //return new Person
            //{
            //    Id = IncrementAndGet(),
            //    FirstName = "RandomName",
            //    LastName = "RandomLastName",
            //    Address = "RandomAddress, , Ontario - CA",
            //    Gender = "Female"
            //};
            //}
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "RandomName",
                LastName = "RandomLastName",
                Address = "RandomAddress, , Ontario - CA",
                Gender = "Female"
            };


        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person { Id = IncrementAndGet(),
                FirstName = "Alyson",
                LastName = "Ramos" ,
                Address = "Stratford, Ontario - CA",
                Gender = "Male" };

        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
