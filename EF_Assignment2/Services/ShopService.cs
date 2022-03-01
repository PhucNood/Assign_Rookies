using System.Data;
using EF_Assignment2.Models;
using EF_Assignment2.Context;
using AutoMapper;
using EF_Assignment2.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace EF_Assignment2.Services
{
    public class ShopService : IShopService
    {
        private readonly ShopContext _context;
        private readonly IDbContextTransaction _transaction;
        public ShopService(ShopContext context)
        {
            _context = context;
            _transaction =  _context.Database.BeginTransaction();
        }

        public void CreateCategory(CategoryEntity category)
        {
            try
            {             
            category.Products =GetProducts().Where(p=>p.CategoryId == category.Id).ToList();
            GetCategories().Add(category);
             _context.SaveChanges();
             _transaction.Commit();
            }
            catch (System.Exception)
            {               
                _transaction.Rollback();
            }
            
        }

        public void CreateProduct(ProductEntity product)
        {
            try
            {
                 product.Category = GetCategories().FirstOrDefault(c => c.Id==product.CategoryId);
            GetProducts().Add(product);
             _context.SaveChanges();
             _transaction.Commit();
            }
            catch (System.Exception)
            {
                
                _transaction.Rollback();
            }
           
        }

        public void DeleteCategory(int id)
        {
            try
            {
            var deletedCategory = GetCategories().FirstOrDefault(c => c.Id == id);
            _context.Remove(deletedCategory);
            _context.SaveChanges();
            _transaction.Commit();
            }
            catch (System.Exception)
            {
                
               _transaction.Rollback();
            }
           
        }

        public void DeleteProduct(int id)
        {
            try
            {
                 var deletedProduct = GetProducts().FirstOrDefault(p => p.Id == id);
            _context.Remove(deletedProduct);
            _context.SaveChanges();
            _transaction.Commit();
            }
            catch (System.Exception)
            {
                
              _transaction.Rollback();
            }
           
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
            try
            {
                 category.Products =GetProducts().Where(p=>p.CategoryId == category.Id).ToList();
            _context.Update(category);
            _context.SaveChanges();
            _transaction.Commit();
            }
            catch (System.Exception)
            {
                
                _transaction.Rollback();
            }
           
        }

        public void UpdateProduct(ProductEntity product)
        {
            try
            {
                 product.Category = GetCategories().FirstOrDefault(c => c.Id==product.CategoryId);
           _context.Update(product);
           _context.SaveChanges();
           _transaction.Commit();
            }
            catch (System.Exception)
            {
                
              _transaction.Rollback();
            }
            
        }
    }

}