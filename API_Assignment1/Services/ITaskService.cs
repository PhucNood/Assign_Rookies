using Microsoft.AspNetCore.Mvc;
using API_Assignment1.Models;
namespace API_Assignment1.Services
{
    public interface ITaskService
    {
        public void CreateTask(TaskModel task);
        public List<TaskModel> GetAllTasks();
        public TaskModel GetTask(int id);

        public void DeleteTask(int id);

        public void EditTask(TaskModel task);

        public void AddTasks(List<TaskModel> tasks);
        public void DeleteTasks(int[] ids);
    }

}
