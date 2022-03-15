
using Microsoft.EntityFrameworkCore;


namespace Back_end.Context;
public class LibraryContext : DbContext
{
    public LibraryContext() { }
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }



}