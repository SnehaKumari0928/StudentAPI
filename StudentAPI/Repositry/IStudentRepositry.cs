using StudentAPI.Models;
using StudentAPI.Models;
namespace StudentAPI.Repositry
{
    public interface IStudentRepositry
    {
        public List<StudentModel> GetAll();
        public StudentModel GetById(int id);
        public void Create(StudentModel student);
        public void Update(StudentModel student,int id);
        public void Delete(int id);
    }
}
