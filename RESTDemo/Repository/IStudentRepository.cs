using RESTDemo.Model;

namespace RESTDemo.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        int AddStudent(Student student);
        Student GetStudentById(int id);
        int UpdateStudent(Student student);
        int DeleteStudent(int id);
        IEnumerable<Student> GetStudentByName(string name);
    }
}
