using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Reward.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public List<Award> Rewards { get; set; }

        public List<AwardViewModel> AvailableRewards { get; set; }

        public User ToUser()
        {
            return new User
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Birthdate = Birthdate,
                Rewards = AvailableRewards
                    .Where(r => r.Checked == true)
                    .Select(r => new Award
                    {
                        Id = r.Id,
                        Title = r.Title,
                        Description = r.Description
                    }).ToList()
            };
        }
        public static UserViewModel GetViewModel(User user, List<Award> availableRewards)
        {
            var userModel = new UserViewModel();
            userModel.Id = user.Id;
            userModel.FirstName = user.FirstName;
            userModel.LastName = user.LastName;
            userModel.Birthdate = user.Birthdate;
            userModel.Rewards = user.Rewards;
            var rewards = new List<AwardViewModel>();
            foreach (var reward in availableRewards)
            {
                rewards.Add(AwardViewModel.GetViewModel(reward, user.Rewards));
            }

            userModel.AvailableRewards = rewards.ToList();
            return userModel;
        }
    }
}