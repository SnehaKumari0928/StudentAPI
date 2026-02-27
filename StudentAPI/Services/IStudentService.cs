using StudentAPI.Models;

namespace StudentAPI.Service

{
    public interface IStudentService
    {
        public List<StudentModel> GetAll();
        public StudentModel GetById(int id);
        public void Create(StudentModel student);
        public void Update(StudentModel student,int id);
        public void Delete(int id);
    }
}
