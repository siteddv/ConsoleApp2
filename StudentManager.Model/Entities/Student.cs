using StudentManager.Backend.Entities;

namespace StudentManager.Backend.Entiries
{
    public class Student : BaseEntity<int>
    {
        public int Age { get; set; }
        public virtual List<StudentsSkills> StudentsSkills { get; set; }
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public List<Skill> GetSkills()
        {
            return StudentsSkills.Select(sk => sk.Skill).ToList();
        }

        public Student(){
            StudentsSkills = new List<StudentsSkills>();
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
