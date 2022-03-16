using AutoMapper;
using Back_end.Entities;
using Back_end.Models;
namespace Back_end.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookModel>();
            CreateMap<BookModel, Book>();
            CreateMap<User, BookModel>();
            CreateMap<UserModel, User>();
            CreateMap<BookBorrowingRequest, BookBorrowingRequestModel>();
            CreateMap<BookBorrowingRequestModel, BookBorrowingRequest>();
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();
        }
    }
}