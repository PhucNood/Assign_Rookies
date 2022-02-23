using EF_Assignment1.Context;
using EF_Assignment1.Models;

namespace EF_Assignment1.Services
{
    public class StudentService : IStudentService
    {

        private readonly StudentDbContext _context;
        public StudentService(StudentDbContext context)
        {
            _context = context;
        }
        public void Create(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deletedStudent = GetStudents().FirstOrDefault(x => x.StudentId == id);
            if (deletedStudent != null)
            {
                _context.Remove(deletedStudent);
                _context.SaveChanges();
            }

        }

        public Student GetStudent(int id)
        {
            var student = GetStudents().FirstOrDefault(x => x.StudentId == id);
             if(student!=null){
                 return student;
             }
             return new Student();
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public void Update(Student student)
        {
            var updatedStudent = GetStudents().FirstOrDefault(x => x.StudentId == student.StudentId);
            if (updatedStudent != null)
            {
                updatedStudent.FirstName = student.FirstName;
                updatedStudent.LastName = student.LastName;
                updatedStudent.City = student.City;
                updatedStudent.State = student.State;
                _context.Update(updatedStudent);
                _context.SaveChanges();
            }
        }
    }
}