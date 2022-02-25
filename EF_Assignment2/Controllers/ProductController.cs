using System.Net;
using AutoMapper;
using EF_Assignment2.Context;
using EF_Assignment2.Entities;
using EF_Assignment2.Models;
using EF_Assignment2.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF_Assignment2.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IShopService _service;
    private readonly IMapper _mapper;


    public ProductController(IShopService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
        
    }

    [HttpGet("api/products")]
    public List<Product> GetProducts()
    {
        return _mapper.Map<List<Product>>(_service.GetProducts());
    }


    [HttpGet("api/product")]
    public Product GetProduct(int id)
    {
        return _mapper.Map<Product>(_service.GetProduct(id));
    }

    [HttpPost("api/product")]
    public HttpStatusCode CreateProduct(Product product)
    {

        if (ModelState.IsValid)
        {
            ProductEntity pe = _mapper.Map<ProductEntity>(product);
            _service.CreateProduct(pe);
            return HttpStatusCode.OK;
        }

        return HttpStatusCode.BadRequest;
    }
    [HttpDelete("api/product")]
    public HttpStatusCode DeleteProduct(int id){
          if(id!=null){
              _service.DeleteProduct(id);
            return HttpStatusCode.OK;
          }

        return HttpStatusCode.BadRequest;
    }

    [HttpPut("api/product")]
    public HttpStatusCode UpdateProduct(Product product){
             if(ModelState.IsValid){
                  _service.UpdateProduct(_mapper.Map<ProductEntity>(product)); ;
                  
                 return HttpStatusCode.OK;
             }
        return HttpStatusCode.BadRequest;
    }

}