using StudentAPI.Models;

namespace StudentAPI.Repositry
{
    public interface IClasses
    {
        public List<ClassesModel> GetAllClasses();

        public ClassesModel GetById(int id);
        public void Create(ClassesModel classes);

        public void Update(int id);

        public void Delete(int id);

    }
}
