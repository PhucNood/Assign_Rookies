using Microsoft.AspNetCore.Mvc;
using Back_end.Services;
using Back_end.Entities;
using Back_end.Models;
using AutoMapper;

namespace Back_end.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{

    private readonly IService<Book> _bookService;
   private readonly IMapper _mapper;

    public BookController(IService<Book> bookService,IMapper mapper)
    {
      _bookService= bookService;
      _mapper= mapper;
    }
    
    [HttpGet("api/Books")]
    public ICollection<BookModel> GetBooks(){
       return _mapper.Map<List<BookModel>>(_bookService.GetAll());
    }

}