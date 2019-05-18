using ASP.Reward.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Reward.Controllers
{
    public class RewardController : Controller
    {
        private static List<Award> awards = new List<Award>();
        // GET: Reward
        public ActionResult Index()
        {
            return View(awards);
        }

        //private static List<User> users = new List<User>();

        public ActionResult Edit(int awarsId)
        {
            var currentAward = awards.FirstOrDefault(u => u.Id == awarsId);
            return View(AwardViewModel.GetViewModel(currentAward, awards));
        }

        public ActionResult Add()
        {
            return View("Edit", null);
        }

        public ActionResult Delete(int userId)
        {
            var currentUser = awards.FirstOrDefault(u => u.Id == userId);
            if (currentUser != null)
            {
               awards.Remove(currentUser);
            }

            return RedirectToAction("Index");
        }

        //public ActionResult Save(AwardViewModel awardModel)
        //{
        //    if (awardModel != null)
        //    {
        //        if (awardModel.Id == default(int))
        //        {
        //            // add
        //            awards.Add(awardModel.ToAward);
        //        }
        //        else
        //        {
        //            // update
        //            var currentUser = awards.FirstOrDefault(u => u.Id == awardModel.Id);
        //            if (currentUser != null)
        //            {
        //                var award = awardModel.ToUser();
        //                currentUser.Title = award.Title;
        //                currentUser.Description= award.Description;
        //            }
        //        }
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}