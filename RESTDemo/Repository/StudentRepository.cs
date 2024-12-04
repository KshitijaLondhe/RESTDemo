using RESTDemo.Data;
using RESTDemo.Model;

namespace RESTDemo.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext db;
        public StudentRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddStudent(Student student)
        {
            int result;
            db.Students.Add(student);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteStudent(int id)
        {
            int result = 0;
            var b = db.Students?.Where(x => x.id == id).FirstOrDefault();
            if (b != null)
            {
                db.Students.Remove(b);
                result = db.SaveChanges();
            }
            return result;
        }

        public Student GetStudentById(int id)
        {
            return db.Students?.Where(x => x.id == id).FirstOrDefault();
        }

        public IEnumerable<Student> GetStudentByName(string name)
        {
            var model = db.Students?.Where(x => x.name.Contains(name)).ToList();
            return model;
        }

        public IEnumerable<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        public int UpdateStudent(Student student)
        {
            int result = 0;
            var b = db.Students?.Where(x => x.id == student.id).FirstOrDefault();
            if (b != null)
            {
                b.name = student.name;
                b.percentage = student.percentage;
                b.branch = student.branch;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
