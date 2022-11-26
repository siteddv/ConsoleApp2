using StudentManager.Backend.Identity;
using StudentManager.WebApp.Areas.Identity.Data;

namespace StudentManager.WebApp.Areas
{
    public interface IShortedUserController
    {
        public void AddUser(Mozgoeb user, double weight);
    }
}
