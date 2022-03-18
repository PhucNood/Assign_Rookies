using Back_end.Entities;
using Back_end.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Back_end.Services
{
    public class CategoryService : IService<Category>
    {
        private readonly LibraryContext _context;
        private readonly IDbContextTransaction _transaction;

        public CategoryService(LibraryContext context)
        {
            _context = context;
            _transaction = _context.Database.BeginTransaction();
        }
        public void Add(Category item)
        {
            Transact(item =>
            {
                _context.Categories.Add(item);
            }, item);
        }

        public bool Existed(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool IsIncorrectFK(Category item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Category item)
        {
            Transact(item =>
            {
                _context.Categories.Remove(item);
            }, item);
        }

        public void Transact(Action<Category> action, Category item)
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

        public void Update(Category item)
        {
            Transact(item =>
            {
                _context.Categories.Update(item);
            }, item);
        }
    }
}