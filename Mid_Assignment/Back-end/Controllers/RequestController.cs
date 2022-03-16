using Microsoft.AspNetCore.Mvc;
using Back_end.Services;
using Back_end.Entities;
using Back_end.Models;
using AutoMapper;
namespace Back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
         private readonly IService<BookBorrowingRequest> _bookBorrowingRequestService;
        private readonly IMapper _mapper;

        public RequestController(IService<BookBorrowingRequest> bookBorrowingRequestService, IMapper mapper)
        {
            _bookBorrowingRequestService = bookBorrowingRequestService;
            _mapper = mapper;
        }

        [HttpGet("api/BookBorrowingRequests")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookBorrowingRequestModel>))]
        public IActionResult GetbookBorrowingRequest()
        {
            var bookBorrowingRequest = _mapper.Map<List<BookBorrowingRequestModel>>(_bookBorrowingRequestService.GetAll());
            if (!ModelState.IsValid) return BadRequest(bookBorrowingRequest);
            return Ok(bookBorrowingRequest);
        }

        [HttpGet("api/BookBorrowingRequest")]
    [ProducesResponseType(200, Type = typeof(BookBorrowingRequestModel))]

    public IActionResult GetbookBorrowingRequest(int id)
    {
        if (!_bookBorrowingRequestService.Existed(id)) return NotFound();
        var bookBorrowingRequest = _mapper.Map<BookBorrowingRequestModel>(_bookBorrowingRequestService.GetById(id));
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(bookBorrowingRequest);
    }

    [HttpPost("api/BookBorrowingRequest")]
    [ProducesResponseType(200, Type = typeof(BookBorrowingRequestModel))]
    
    public IActionResult PostbookBorrowingRequest(BookBorrowingRequestModel bookBorrowingRequestModel)
    {
       var bookBorrowingRequest = _mapper.Map<BookBorrowingRequest>(bookBorrowingRequestModel);

      if(bookBorrowingRequestModel == null) return BadRequest(ModelState);
      
      if(!ModelState.IsValid){
           ModelState.AddModelError("","May be not have the bookBorrowingRequest or request");
      } 
      
      
        if(ModelState.IsValid){
        
         _bookBorrowingRequestService.Add(bookBorrowingRequest);
         return Ok(bookBorrowingRequest);
         } 
      return BadRequest(ModelState);
    }

    [HttpPut("api/BookBorrowingRequest")]
      [ProducesResponseType(204)]
      [ProducesResponseType(400)]
    
    public IActionResult UpdatebookBorrowingRequest(BookBorrowingRequestModel bookBorrowingRequestModel)
    {
       var bookBorrowingRequest = _mapper.Map<BookBorrowingRequest>(bookBorrowingRequestModel);

      if(bookBorrowingRequestModel == null) return BadRequest(ModelState);
      if(_bookBorrowingRequestService.IsIncorrectFK(bookBorrowingRequest)) {
        ModelState.AddModelError("InvalidFK","May be Invalid some foreign key ");
        return StatusCode(422,ModelState);
      }
      if(!ModelState.IsValid){
           ModelState.AddModelError("","May be not have the bookBorrowingRequest or request");
      } 
      
      
       if(ModelState.IsValid){
        
         _bookBorrowingRequestService.Update(bookBorrowingRequest);
         return Ok(bookBorrowingRequestModel);
         } 
      return BadRequest(ModelState);
    }

    [HttpDelete("api/BookBorrowingRequest")]
    [ProducesResponseType(200, Type = typeof(BookBorrowingRequestModel))]

    public IActionResult DeleteBookBorrowingRequest(int id)
    {
        if (!_bookBorrowingRequestService.Existed(id)) return NotFound();
        var bookBorrowingRequests = _mapper.Map<BookBorrowingRequestModel>(_bookBorrowingRequestService.GetById(id));
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(bookBorrowingRequests);
    }

    }
}