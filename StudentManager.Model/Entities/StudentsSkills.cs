using StudentManager.Backend.Entiries;

namespace StudentManager.Backend.Entities
{
    public class StudentsSkills
    {
        public int StudentId { get; set; }
        public int SkillId { get; set; }
        public Student Student { get; set; }
        public Skill Skill { get; set; }
    }
}
