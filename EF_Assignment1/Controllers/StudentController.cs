using Microsoft.AspNetCore.Mvc;
using EF_Assignment1.Models;
using EF_Assignment1.Context;
using EF_Assignment1.Services;
using System.Net;

namespace EF_Assignment1.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{

    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    [HttpGet("api/students")]
    public IEnumerable<Student> GetStudents()
    {

        return _studentService.GetStudents();

    }
     [HttpGet("api/student")]
    public Student GetStudent(int id)
    {

        return _studentService.GetStudent(id);

    }

     [HttpPost("api/created-student")]
    public HttpStatusCode CreatedStudent(Student student)
    {

        if(ModelState.IsValid){
            _studentService.Create(student);
            return HttpStatusCode.OK;
        }
           return HttpStatusCode.BadRequest;
    }

    [HttpDelete("api/deleted-student")]
    public HttpStatusCode DeletedStudent(int id)
    {

        if(id!=null){
            _studentService.Delete(id);
            return HttpStatusCode.OK;
        }
           return HttpStatusCode.BadRequest;
    }

    [HttpPut("api/updated-student")]
    public HttpStatusCode UpdateStudent(Student student)
    {

        if(ModelState.IsValid){
            _studentService.Update(student);
            return HttpStatusCode.OK;
        }
           return HttpStatusCode.BadRequest;
    }

}