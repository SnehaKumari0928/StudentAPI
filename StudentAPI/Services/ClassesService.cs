using StudentAPI.Models;
using StudentAPI.Repositry;

namespace StudentAPI.Services
{
    public class ClassesService : IClassesService
    {
        IClassesRepositry repo;

        public ClassesService(IClassesRepositry _repo)
        {
            repo = _repo;

        }

        public List<ClassesModel> GetAllClasses()
        {
            return repo.GetAllClasses();
        }

        public ClassesModel GetById(string classname)
        {
            return repo.GetById(classname);
        }

        public void Create(ClassesModel classes)
        {
            repo.Create(classes);
        }
        public void Update(string classname,ClassesModel classes)
        {
            repo.Update(classname, classes);
        }

        public void Delete(string classname)
        {
            repo.Delete(classname);
        }
    }
}
