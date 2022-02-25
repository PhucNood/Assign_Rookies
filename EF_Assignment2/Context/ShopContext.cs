using EF_Assignment2.Entities;
using Microsoft.EntityFrameworkCore;


namespace EF_Assignment2.Context {
    public class ShopContext : DbContext {
        public ShopContext() { }
        public ShopContext(DbContextOptions<ShopContext> options) : base (options) { }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DBName;Integrated Security=True");
        // }

        public virtual DbSet<CategoryEntity> CategoryEntitys { get; set; }
        public virtual DbSet<ProductEntity> ProductEntitys { get; set;}
    
    }
}