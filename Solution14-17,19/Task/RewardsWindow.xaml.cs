using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Task.Windows
{
    public partial class RewardsWindow : Window 
    {


        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

       

        public RewardsWindow()
        {
        

            InitializeComponent();
            WindowRewards.Loaded += WindowRewards_Loaded;
            bActionReward.Click += BActionReward_Click;
        }

        void WindowRewards_Loaded(object sender, RoutedEventArgs e)
        {
            switch (Properties.Settings.Default.RewardsState)
            {
                case 1:
                    lStateRewards.Content = "Удаление награды";
                    bActionReward.Content = "Удалить";
                    WindowRewards.Title = "Удаление";
                    break;
                case 2:
                    lStateRewards.Content = "Изменение награды";
                    bActionReward.Content = "Изменить";
                    WindowRewards.Title = "Изменение";
                    break;
                case 3:
                    lStateRewards.Content = "Добавление награды";
                    bActionReward.Content = "Добавить";
                    WindowRewards.Title= "Добавление";
                    break;
            }
        }

        private void BActionReward_Click(object sender, RoutedEventArgs e)
        {
            string name = tbTitle.Text;
            string description = tbDescription.Text;

            Award award = new Award(name, description);

            switch (Properties.Settings.Default.UsersState)
            {
                case 1:
                    RewardingBLL.AwardLogic.Remove(award);
                    break;
                case 2:
                    RewardingBLL.AwardLogic.EditAward(award);
                    break;
                case 3:
                    RewardingBLL.AwardLogic.Add(award);
                    break;
            }
        }
    }
}
