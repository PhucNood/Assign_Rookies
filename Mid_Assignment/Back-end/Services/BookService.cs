using Back_end.Entities;
using Back_end.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Back_end.Services
{
    public class BookService : IService<Book>
    {
        private readonly LibraryContext _context;
        private readonly IDbContextTransaction _transaction;

        public BookService(LibraryContext context)
        {
            _context = context;
            _transaction = _context.Database.BeginTransaction();
        }
        public void Add(Book book)
        {
            Transact(book =>
            {
                _context.Books.Add(book);

            }, book);
        }

        public bool Existed(int id)
        {
            return _context.Books.Any(b => b.Id == id);
        }

        public ICollection<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return GetAll().FirstOrDefault(book => book.Id == id);
        }

        public void Remove(Book book)
        {
            Transact(book =>
            {
                _context.Books.Remove(book);
            }, book);
        }

        public void Update(Book book)
        {

            Transact(book =>
            {
                _context.Books.Update(book);
            }, book);

        }

        public bool IsIncorrectFK(Book b)
        {
            if (_context.Categories.Any(c => c.Id == b.CategoryId)) return false;
          
            return true;
        }

        public void Transact(Action<Book> action, Book item)  // transact delegeta crud
        {
            try
            {
                action(item);
                _context.SaveChanges();
                _transaction.Commit();
            }
            catch (System.Exception)
            {
                _transaction.Rollback();
            }
        }
    }
}