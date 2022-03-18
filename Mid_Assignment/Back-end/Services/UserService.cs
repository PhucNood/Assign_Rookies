using Back_end.Entities;
using Back_end.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Back_end.Services
{
    public class UserService : IService<User>
    {
        private readonly LibraryContext _context;
        private readonly IDbContextTransaction _transaction;

        public UserService(LibraryContext context)
        {
            _context = context;
            _transaction = _context.Database.BeginTransaction();
        }
        public void Add(User item)
        {
            Transact(item =>
            {
                _context.Users.Add(item);
            }, item);
        }

        public bool Existed(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return GetAll().FirstOrDefault(book => book.Id == id);
        }

        public bool IsIncorrectFK(User item)
        {
            throw new NotImplementedException();
        }

        public void Remove(User item)
        {
            Transact(item =>
            {
                _context.Users.Remove(item);
            }, item);
        }

        public void Transact(Action<User> action, User item)
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

        public void Update(User item)
        {
            Transact(item =>
            {
                _context.Users.Update(item);
            }, item);
        }
    }
}