using Back_end.Entities;
using Back_end.Context;

namespace Back_end.Services
{
    public class BookService : IService<Book>
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }
        public void Add(Book book)
        {
            throw new NotImplementedException();
        }

        public ICollection<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Book item)
        {
            throw new NotImplementedException();
        }

        public void Update(Book item)
        {
            throw new NotImplementedException();
        }
    }
}