using StudentManager.Backend.Contexts;
using StudentManager.Backend.Identity;
using StudentManager.WebApp.Areas;
using StudentManager.WebApp.Areas.Identity.Data;

namespace StudentManager.WebApp.Controllers
{
    public class ShortenUserController : IShortedUserController
    {
        private readonly AppDbContext _dbContext;

        public ShortenUserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(Mozgoeb user, double weight)
        {
            var shortenUser = MapUser(user);
            ExpandUserModel(shortenUser, weight);
            _dbContext.Users.Add(shortenUser);

            _dbContext.SaveChanges();
        }

        private void ExpandUserModel(ShortenUser user, double weight)
        {
            user.Weight = weight;
        }

        private ShortenUser MapUser(Mozgoeb mozgoeb)
        {
            return new ShortenUser()
            {
                Id = mozgoeb.Id,
                Nickname = mozgoeb.UserName,
                Name = mozgoeb.UserName
            };
        }
    }
}
