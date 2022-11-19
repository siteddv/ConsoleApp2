using StudentManager.Backend.Entiries;

namespace StudentManager.Infrastructure.Managers.Interfaces
{
    public interface IStudentsManager
    {
        public List<Student> GetAllStudents();
    }
}
