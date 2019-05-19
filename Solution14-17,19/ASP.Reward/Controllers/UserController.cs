using ASP.Reward.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Reward.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View(users);
        }

            private static List<Award> rewards = new List<Award>
        {
            new Award { Id = 1, Title = "Награда 1-ой степени", Description = "Некое описание"},
            new Award{ Id = 2, Title = "Награда 2-ой степени", Description = "Некое описание"},
            new Award { Id = 3, Title = "Награда 3-ой степени", Description = "Некое описание"}
        };
        private static List<User> users = new List<User>
        {
            new User { Id = 1, FirstName = "Роман", LastName = "Третьякович", Birthdate = new DateTime(1999, 11, 12), Rewards = new List<Award> { rewards[2] } },
            new User { Id = 2, FirstName = "Алексей", LastName = "Березин", Birthdate = new DateTime(1990, 7, 2), Rewards = new List<Award> { rewards[1], rewards[2] } },
            new User { Id = 3, FirstName = "Роман", LastName = "Викторович", Birthdate = new DateTime(2011, 6, 15)},
        };
        public UserController()
        {
            //service = new DataService();
        }

        public ActionResult Edit(int userId)
        {
            var currentUser = users.FirstOrDefault(u => u.Id == userId);
            return View(UserViewModel.GetViewModel(currentUser, rewards));
        }

        public ActionResult Add(UserViewModel userModel)
        {
            if (userModel != null)
            {
                if (userModel.Id == default(int))
                {
                    users.Add(userModel.ToUser());
                }
            }
            return View("Edit", null);
        }

        public ActionResult Delete(int userId)
        {
            var currentUser = users.FirstOrDefault(u => u.Id == userId);
            if (currentUser != null)
            {
                users.Remove(currentUser);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Save(UserViewModel userModel)
        {
            if (userModel != null)
            {
                if (userModel.Id == default(int))
                {
                    users.Add(userModel.ToUser());
                }
                else
                {
                    var currentUser = users.FirstOrDefault(u => u.Id == userModel.Id);
                    if (currentUser != null)
                    {
                        var user = userModel.ToUser();
                        currentUser.FirstName = user.FirstName;
                        currentUser.LastName = user.LastName;
                        currentUser.Birthdate = user.Birthdate;
                        currentUser.Rewards = user.Rewards;
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}