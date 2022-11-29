using Microsoft.EntityFrameworkCore;
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

        public void Add(Student student)
        {
            _repository.Create(student);
        }

        public Student Delete(int id)
        {
            var student = _repository.DeleteById(id);
            if (student == null)
            {
                return null;
            }

            return student;
        }

        public List<Student> GetAll()
        {
            return _repository.ReadAll();
        }

        public Student GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var student = _repository.ReadById(id.Value);

            return student;
        }

        public Student Update(int id, Student student)
        {
            try
            {
                _repository.Update(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.IsExists(student.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return student;
        }
    }
}
