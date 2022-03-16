
using Microsoft.EntityFrameworkCore;
using Back_end.Entities;


namespace Back_end.Context;
public class LibraryContext : DbContext
{
    public LibraryContext() { }
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    public virtual DbSet<Book> Books{get; set; }
    public virtual DbSet<Category> Categories{get; set;}
    public virtual DbSet<Author> Authors{get; set;}
    public virtual DbSet<User> Users{get; set;}

      public virtual DbSet<BookBorrowingRequest > BookBorrowingRequests{get; set;}

    public virtual DbSet<BookeBorrowingRequestDetails> BookeBorrowingRequestDetails{get; set;}

   

}