using System.Net;
using Microsoft.AspNetCore.Mvc;
using API_Assignment1.Services;
using API_Assignment1.Models;
namespace API_Assignment1.Controllers;

[ApiController]
[Route("[controller]")]

public class TaskController : ControllerBase
{
  private readonly ITaskService _taskService;

  public TaskController(ITaskService taskService){
      _taskService=taskService;
  }

 [HttpGet("api/tasks")]
  public IEnumerable<TaskModel> Tasks(){
        
        return _taskService.GetAllTasks();
  }

[HttpGet("api/task")]
  public TaskModel Task(int id){
        
        return _taskService.GetTask(id);
  }


[HttpPost("api/created-task")]
   public HttpStatusCode CreateTask(TaskModel task){
       _taskService.CreateTask(task);
         return HttpStatusCode.OK;

}
[HttpDelete("api/deleted-task{id}")]
   public HttpStatusCode DeleteTask(int id){
       _taskService.DeleteTask(id);
         return HttpStatusCode.OK;

}

[HttpPut("api/edited-task")]
   public HttpStatusCode EditTask(TaskModel task){
       _taskService.EditTask(task);
         return HttpStatusCode.OK;

}


}