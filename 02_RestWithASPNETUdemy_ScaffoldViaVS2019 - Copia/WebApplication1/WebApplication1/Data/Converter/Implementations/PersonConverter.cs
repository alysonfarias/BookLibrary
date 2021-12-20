﻿using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data.Converter.Contract;
using WebApplication1.Data.VO;
using WebApplication1.Model;

namespace WebApplication1.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return null;
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName =origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };

        }
        public PersonVO Parse(Person origin)
        {
            if (origin == null) return null;
            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }
        public List<Person> Parse(List<PersonVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList(); 
        }
        public List<PersonVO> Parse(List<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
