using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Model;
using WebApplication1.Model.Context;
using WebApplication1.Repository.Generic;

namespace WebApplication1.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(MySQLContext context) : base(context) { }

        public Person Disable(long id)
        {
            if (!_context.People.Any(p => p.Id.Equals(id))) return null;
            var user = _context.People.SingleOrDefault(p => p.Id.Equals(id));
            if(user != null)
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return user;
        }

    public List<Person> findByName(string firstName, string lastName)
    {
      if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
      {
        return _context.People.Where(
        p => p.FirstName.Contains(firstName)
        && p.LastName.Contains(lastName)).ToList();
      }else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
      {
        return _context.People.Where(p => p.LastName.Contains(lastName)).ToList();
      } else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
      {
        return _context.People.Where(
        p => p.FirstName.Contains(firstName)).ToList();
      }
      return null;

    }
  }
}
