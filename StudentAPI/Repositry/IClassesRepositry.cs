using StudentAPI.Models;

namespace StudentAPI.Repositry
{
    public interface IClassesRepositry
    {
        public List<ClassesModel> GetAllClasses();

        public ClassesModel GetById(string classname);
        public void Create(ClassesModel classes);

        public void Update(string classname,ClassesModel classes);

        public void Delete(string classname);

    }
}
