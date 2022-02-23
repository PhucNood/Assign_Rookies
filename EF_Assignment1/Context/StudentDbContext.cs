using Microsoft.EntityFrameworkCore;
using EF_Assignment1.Models;
namespace EF_Assignment1.Context {
    public class StudentDbContext : DbContext {
        public StudentDbContext() { }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base (options) { }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DBName;Integrated Security=True");
        // }

        public virtual DbSet<Student> Students { get; set; }


    }
}

