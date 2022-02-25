using EF_Assignment2.Models;
using EF_Assignment2.Context;
using AutoMapper;
using EF_Assignment2.Entities;

namespace EF_Assignment2.Services
{
    public class ShopService : IShopService
    {
        private readonly ShopContext _context;
       
        public ShopService(ShopContext context)
        {
            _context = context;
            
        }

        public void CreateCategory(CategoryEntity category)
        {
             category.Products =GetProducts().Where(p=>p.CategoryId == category.Id).ToList();
            GetCategories().Add(category);
             _context.SaveChanges();
        }

        public void CreateProduct(ProductEntity product)
        {
            product.Category = GetCategories().FirstOrDefault(c => c.Id==product.CategoryId);
            GetProducts().Add(product);
             _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var deletedCategory = GetCategories().FirstOrDefault(c => c.Id == id);
            _context.Remove(deletedCategory);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var deletedProduct = GetProducts().FirstOrDefault(p => p.Id == id);
            _context.Remove(deletedProduct);
            _context.SaveChanges();
        }

        public List<CategoryEntity> GetCategories()
        {
            return _context.CategoryEntitys.ToList();
        }

        public CategoryEntity GetCategory(int id)
        {
            return GetCategories().FirstOrDefault(c => c.Id == id);
        }

        public ProductEntity GetProduct(int id)
        {
           return GetProducts().FirstOrDefault(p => p.Id == id);
        }

        public List<ProductEntity> GetProducts()
        {
            return _context.ProductEntitys.ToList();
        }

        public void UpdateCategory(CategoryEntity category)
        {
            category.Products =GetProducts().Where(p=>p.CategoryId == category.Id).ToList();
            _context.Update(category);
            _context.SaveChanges();
        }

        public void UpdateProduct(ProductEntity product)
        {
             product.Category = GetCategories().FirstOrDefault(c => c.Id==product.CategoryId);
           _context.Update(product);
           _context.SaveChanges();
        }
    }

}