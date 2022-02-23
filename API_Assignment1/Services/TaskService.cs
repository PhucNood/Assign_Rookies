using API_Assignment1.Models;

namespace API_Assignment1.Services
{
    public class TaskService : ITaskService
    {
        public static List<TaskModel> Tasks = new List<TaskModel>{new TaskModel{Id=1,Title="Task 1",IsCompleted=true},
        new TaskModel{Id=2,Title="Task 2",IsCompleted=true},
        new TaskModel{Id=3,Title="Task 3",IsCompleted=false},
        new TaskModel{Id=4,Title="Task 4",IsCompleted=false},
        new TaskModel{Id=5,Title="Task 5",IsCompleted=true}};

        public void AddTasks(List<TaskModel> tasks)
        {
           foreach (var t in tasks)
            {
                t.Id = Tasks.Max(t => t.Id)+1;
            }
            Tasks.AddRange(tasks);
        }

        public void CreateTask(TaskModel task)
        {
            task.Id = Tasks.Max(task => task.Id)+1;
            Tasks.Add(task);
        }

        public void DeleteTask(int id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if(task != null) Tasks.Remove(task);
        }

        public void DeleteTasks(int[] ids)
        {
             Tasks.RemoveAll(task=> ids.Contains(task.Id));
        }

        public void EditTask(TaskModel task)
        {
           TaskModel EditTask = Tasks.FirstOrDefault(t => t.Id ==task.Id);
           if(EditTask != null) {
               EditTask.Id = task.Id;
               EditTask.Title = task.Title;
               EditTask.IsCompleted = task.IsCompleted;
           }
        }

        public List<TaskModel> GetAllTasks()
        {
           return Tasks;
        }

        public TaskModel GetTask(int id)
        {
            TaskModel task= Tasks.FirstOrDefault(t=>t.Id == id);
             if(task!=null) return task;
             return new TaskModel();
        }
    }
}