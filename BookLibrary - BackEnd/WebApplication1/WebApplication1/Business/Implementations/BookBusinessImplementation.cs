using System.Collections.Generic;
using WebApplication1.Data.Converter.Implementations;
using WebApplication1.Model;
using WebApplication1.Repository;
using WebApplication1.Repository.Generic;

namespace WebApplication1.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;
        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }
        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }
        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }
    }
}
