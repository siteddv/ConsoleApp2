using StudentManager.Backend.Entiries;
using StudentManager.Backend.Repositories;
using StudentManager.Infrastructure.Managers.Interfaces;

namespace StudentManager.Infrastructure.Managers.Implemetations
{
    public class StudentsManager : IStudentsManager
    {
        private readonly IRepository<Student, int> _repository;

        public StudentsManager(IRepository<Student, int> repository)
        {
            _repository = repository;
        }

        public List<Student> GetAllStudents()
        {
            return _repository.ReadAll();
        }
    }
}
