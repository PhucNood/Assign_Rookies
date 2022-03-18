using Back_end.Entities;
using Back_end.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Back_end.Services
{
    public class RequestService : IService<BookBorrowingRequest>
    {

        private readonly LibraryContext _context;
        private readonly IDbContextTransaction _transaction;

        public RequestService(LibraryContext context)
        {
            _context = context;
            _transaction = _context.Database.BeginTransaction();
        }
        public void Add(BookBorrowingRequest item)
        {
            Transact(item =>
            {
                _context.BookBorrowingRequests.Add(item);
            }, item);
        }

        public bool Existed(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        public ICollection<BookBorrowingRequest> GetAll()
        {
            return _context.BookBorrowingRequests.ToList();
        }

        public BookBorrowingRequest GetById(int id)
        {
            return GetAll().FirstOrDefault(r => r.Id == id);
        }

        public bool IsIncorrectFK(BookBorrowingRequest item)
        {
            if (_context.Users.Any(u => u.Id == item.UserId)) return false;
           
            return true;
        }

        public void Remove(BookBorrowingRequest item)
        {
            Transact(item =>
            {
                _context.BookBorrowingRequests.Remove(item);
            }, item);
        }

        public void Transact(Action<BookBorrowingRequest> action, BookBorrowingRequest item)
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

        public void Update(BookBorrowingRequest item)
        {
            Transact(item =>
            {
                _context.BookBorrowingRequests.Update(item);
            }, item);
        }
    }
}