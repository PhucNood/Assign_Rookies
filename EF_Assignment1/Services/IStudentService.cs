using EF_Assignment1.Models;

namespace EF_Assignment1.Services
{
    public interface IStudentService
    {
         public List<Student> GetStudents();
         public Student GetStudent(int id);

         public void Create(Student student);
         public void Update(Student student);
         public void Delete(int id);
    }
}