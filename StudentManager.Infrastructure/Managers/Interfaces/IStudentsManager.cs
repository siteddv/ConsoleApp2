using StudentManager.Backend.Entiries;

namespace StudentManager.Infrastructure.Managers.Interfaces
{
    public interface IStudentsManager
    {
        public List<Student> GetAll();
        Student GetById(int? id);
        void Add(Student student);
        Student Update(int id, Student student);
        Student Delete(int id);
    }
}
