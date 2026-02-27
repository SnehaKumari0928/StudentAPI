
using StudentAPI.Models;
using MySql.Data.MySqlClient;
using StudentAPI.Data;
using StudentAPI.Repositry;

namespace StudentAPI.Service

{
    public class StudentService: IStudentService
    {
        IStudentRepositry repo;
        public StudentService()
        {
            repo=new StudentRepositry();
        }
        public List<StudentModel> GetAll()
        {
           
           return repo.GetAll();

        }
        public StudentModel GetById(int id)
        {
          return  repo.GetById(id); 

        }
        public void Create(StudentModel student)
        {
            repo.Create(student);
        }
        public void Update(StudentModel student,int id)
        {
            repo.Update(student,id);

        }
        public void Delete(int id)
        {
            repo.Delete(id);
        }

       
    }
}
