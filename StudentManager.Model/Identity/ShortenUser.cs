using StudentManager.Backend.Entities;

namespace StudentManager.Backend.Identity
{
    public class ShortenUser : BaseEntity<string>
    {
        public string Nickname { get; set; }
    }
}