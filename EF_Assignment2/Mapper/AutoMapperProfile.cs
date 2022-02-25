using AutoMapper;
using EF_Assignment2.Entities;
using EF_Assignment2.Models;
namespace EF_Assignment2.Mapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<ProductEntity, Product>();
            CreateMap<Product, ProductEntity>();
            CreateMap<Category, CategoryEntity>();
            CreateMap<CategoryEntity, Category>();
        }
    }
}