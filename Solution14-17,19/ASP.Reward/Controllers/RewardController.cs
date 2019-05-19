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


        public ActionResult Edit(int awardId)
        {
            var currentAward = awards.FirstOrDefault(u => u.Id == awardId);
            return View(AwardViewModel.GetViewModel(currentAward, awards));
        }

        public ActionResult Add(AwardViewModel awardModel)
        {
            if (awardModel != null)
            {
                if (awardModel.Id == default(int))
                {
                    awards.Add(awardModel.ToAward());
                }
            }
            return View("Edit", null);
        }

        public ActionResult Delete(int awardId)
        {
            var currentUser = awards.FirstOrDefault(a => a.Id == awardId);
            if (currentUser != null)
            {
               awards.Remove(currentUser);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Save(AwardViewModel awardModel)
        {
            if (awardModel != null)
            {
                if (awardModel.Id == default(int))
                {
                    // add
                    awards.Add(awardModel.ToAward());
                }
                else
                {
                    // update
                    var currentUser = awards.FirstOrDefault(u => u.Id == awardModel.Id);
                    if (currentUser != null)
                    {
                        var award = awardModel.ToAward();
                        currentUser.Title = award.Title;
                        currentUser.Description = award.Description;
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}