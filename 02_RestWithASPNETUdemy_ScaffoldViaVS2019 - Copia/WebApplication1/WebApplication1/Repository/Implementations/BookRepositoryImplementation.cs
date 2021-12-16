using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Model;
using WebApplication1.Model.Context;

namespace WebApplication1.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext _context;
        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }
        // Method responsible for get all the people
        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        // Method responsible for get a specify person from an Id
        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id.Equals(id));
        }

        // Method responsible for create a new person
        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        }

        // Method responsible for delete a person from an Id
        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }


        }

        // Method responsible for update person data
        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(book.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return book;

        }

        // Method responsible for check if a person exists from an Id
        public bool Exists(long id)
        {
            return _context.Books.Any(p => p.Id.Equals(id));
        }
    }
}
