﻿using StudentManager.Backend.Contexts;
using StudentManager.Backend.Indentity;
using StudentManager.WebApp.Areas.Identity;
using StudentManager.WebApp.Areas.Identity.Data;

namespace StudentManager.WebApp.Controllers
{
    public class ShortenUserController
    {
        private readonly AppDbContext _dbContext;

        public ShortenUserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(Mozgoeb user)
        {
            var shortenUser = MapUser(user);
            _dbContext.Users.Add(shortenUser);

            _dbContext.SaveChanges();
        }

        private ShortenUser MapUser(Mozgoeb mozgoeb)
        {
            return new ShortenUser()
            {
                Id = mozgoeb.Id,
                Nickname = mozgoeb.UserName
            };
        }
    }
}
