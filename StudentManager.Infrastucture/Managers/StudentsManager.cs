using StudentManager.Backend.Entiries;
using StudentManager.Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Infrastucture.Managers
{
    public class StudentsManager
    {
        private readonly IRepository<Student> _repository;

        public StudentsManager(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public Student GetStudentDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var student = _repository.ReadById(id.Value);
            return student;
        }
    }
}
