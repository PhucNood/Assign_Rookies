
using EF_Assignment2.Entities;
using EF_Assignment2.Models;

namespace EF_Assignment2.Services
{
    public interface IShopService
    {
        public List<ProductEntity> GetProducts();
        public List<CategoryEntity> GetCategories();

        public ProductEntity GetProduct(int id);
        public CategoryEntity GetCategory(int id);

        public void CreateProduct(ProductEntity product);
        public void CreateCategory(CategoryEntity category);
        public void UpdateProduct(ProductEntity product);
        public void UpdateCategory(CategoryEntity category);
        public void DeleteProduct(int id);

        public void DeleteCategory(int id);
        
        
    }
}