
using System;
using System.Collections.Generic;
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
    //Константы//
    //Remove--удалить--1//
    //Edit--редактировать--2//
    //Add--добавить--3//

    public partial class UserWindow : Window
    {

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public static List<Award> AwardsList = new List<Award>();

        public UserWindow()
        {
            InitializeComponent();
            WindowUser.Loaded += WindowUser_Loaded;
            bAction.Click += BAction_Click;
        }

        private void WindowUser_Loaded(object sender, RoutedEventArgs e)
        {
            switch (Properties.Settings.Default.UsersState)
            {
                case 1:
                    lState.Content = "Удаление пользователя";
                    bAction.Content = "Удалить";
                    WindowUser.Title = "Удаление";
                    LoadedRewards();
                    break;
                case 2:
                    lState.Content = "Изменение пользователя";
                    bAction.Content = "Изменить";
                    WindowUser.Title = "Изменение";
                    LoadedRewards();
                    break;
                case 3:
                    lState.Content = "Добавление пользователя";
                    bAction.Content = "Добавить";
                    WindowUser.Title = "Добавление";
                    LoadedRewards();
                    break;
            }
        }


        private void LoadedRewards()
        {
            AwardsList = RewardingBLL.UserLogic.LoadedUserRewards();

            for (int i = 0; i < AwardsList.Count; i++)
            {
                spWindowRewards.Children.Add(new CheckBox { Content = Convert.ToString(AwardsList[i].Title), ToolTip = Convert.ToString(AwardsList[i].Description) });
            }
        }

        private string CheckBoxAwards()
        {
            string titles = "";
            for (int i=0; i< spWindowRewards.Children.Count; i++)
            {
                if (spWindowRewards.Children[i] is CheckBox)
                {
                    if (spWindowRewards.Children[i].IsEnabled)
                    {
                        titles += AwardsList[i].Title + ',';
                    }
                }
            }
            return titles;
        }

        private void BAction_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            string secondName = tbSecondName.Text;
            DateTime date = DateTime.Parse(tbBirthDate.Text);
            int age = User.CheckAge(date);
            string rewards = CheckBoxAwards();


            User user = new User(name, secondName, date, age, rewards);



            switch (Properties.Settings.Default.UsersState)
            {
                case 1:
                    RewardingBLL.UserLogic.Remove(user);
                    break;
                case 2:
                    RewardingBLL.UserLogic.EditUser(user);
                    break;
                case 3:
                    RewardingBLL.UserLogic.AddUser(user);
                    break;
            }

        }
    }
}
