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

    public BookController(IService<Book> bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet("api/Books")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<BookModel>))]
    public IActionResult GetBooks()
    {
        var books = _mapper.Map<List<BookModel>>(_bookService.GetAll());
        if (!ModelState.IsValid) return BadRequest(books);
        return Ok(books);
    }


    [HttpGet("api/Book")]
    [ProducesResponseType(200, Type = typeof(BookModel))]

    public IActionResult GetBook(int id)
    {
        if (!_bookService.Existed(id)) return NotFound();
        var books = _mapper.Map<BookModel>(_bookService.GetById(id));
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(books);
    }

    [HttpPost("api/Book")]


    public IActionResult PostBook(BookModel bookModel)
    {
        var book = _mapper.Map<Book>(bookModel);

        if (bookModel == null) return BadRequest(ModelState);
        // if (_bookService.IsIncorrectFK(book))
        // {
        //     ModelState.AddModelError("InvalidFK", "May be Invalid some foreign key ");
        //     return StatusCode(422, ModelState);
        // }
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "May be not have the category or request");
        }


        if (ModelState.IsValid)
        {

            _bookService.Add(book);
            return Ok(book);
        }
        return BadRequest(ModelState);
    }

    [HttpPut("api/Book")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]

    public IActionResult UpdateBook(BookModel bookModel)
    {
        var book = _mapper.Map<Book>(bookModel);

        if (bookModel == null) return BadRequest(ModelState);
        if (_bookService.IsIncorrectFK(book))
        {
            ModelState.AddModelError("InvalidFK", "May be Invalid some foreign key ");
            return StatusCode(422, ModelState);
        }
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "May be not have the category or request");
        }


        if (ModelState.IsValid)
        {

            _bookService.Update(book);
            return Ok(book);
        }
        return BadRequest(ModelState);
    }

    [HttpDelete("api/Book")]
    [ProducesResponseType(200, Type = typeof(BookModel))]

    public IActionResult DeleteBook(int id)
    {
        if (id == null) return BadRequest(ModelState);
        if (!_bookService.Existed(id)) return NotFound();
        var books = _bookService.GetById(id);

        if (_bookService.Existed(id))
        {
            _bookService.Remove(books);
            return Ok(id);
        }
        return Ok(books);
    }





}