using Back_end.Entities;
using Back_end.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Back_end.Services
{
    public class RequestService : IService<BookBorrowingRequest>
    {
        public void Add(BookBorrowingRequest item)
        {
            throw new NotImplementedException();
        }

        public bool Existed(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<BookBorrowingRequest> GetAll()
        {
            throw new NotImplementedException();
        }

        public BookBorrowingRequest GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsIncorrectFK(BookBorrowingRequest item)
        {
            throw new NotImplementedException();
        }

        public void Remove(BookBorrowingRequest item)
        {
            throw new NotImplementedException();
        }

        public void Transact(Action<BookBorrowingRequest> action, BookBorrowingRequest item)
        {
            throw new NotImplementedException();
        }

        public void Update(BookBorrowingRequest item)
        {
            throw new NotImplementedException();
        }
    }
}