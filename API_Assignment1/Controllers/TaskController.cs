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

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("api/tasks")]
    public IEnumerable<TaskModel> Tasks()
    {

        return _taskService.GetAllTasks();
    }

    [HttpGet("api/task")]
    public TaskModel Task(int id)
    {
        return _taskService.GetTask(id);
    }


    [HttpPost("api/created-task")]
    public HttpStatusCode CreateTask(TaskModel task)
    {
        if (task != null)
        {
            _taskService.CreateTask(task);
            return HttpStatusCode.OK;
        }
        return HttpStatusCode.BadRequest;

    }
    [HttpDelete("api/deleted-task{id}")]
    public HttpStatusCode DeleteTask(int id)
    {
      if(id !=null){
         _taskService.DeleteTask(id);
        return HttpStatusCode.OK;
      }
        return HttpStatusCode.BadRequest;

    }

    [HttpPut("api/edited-task")]
    public HttpStatusCode EditTask(TaskModel task)
    {
      if (task != null)
        {
        _taskService.EditTask(task);
        return HttpStatusCode.OK;
        }
        return HttpStatusCode.BadRequest;

    }

    [HttpPost("api/bulk-added-task")]
     public HttpStatusCode BulkAddTask(List<TaskModel> tasks)
    {
        if (tasks.Count!=0)
        {
            _taskService.AddTasks(tasks);
            return HttpStatusCode.OK;
        }
        return HttpStatusCode.BadRequest;

    }

 [HttpDelete("api/bulk-added-task")]
     public HttpStatusCode DeleteTasks(int[] ids)
    {
        
            _taskService.DeleteTasks(ids);
            return HttpStatusCode.OK;
        
     

    }


}