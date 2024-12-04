using RESTDemo.Model;

namespace RESTDemo.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        int AddStudent(Student student);
        Student GetStudentById(int id);
        int UpdateStudent(Student student);
        int DeleteStudent(int id);
        IEnumerable<Student> GetStudentByName(string name);
    }
}
