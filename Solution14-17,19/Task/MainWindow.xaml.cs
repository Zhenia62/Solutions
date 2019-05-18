using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.IO;
using Task.Windows;
using System.ComponentModel;

namespace Task
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WindowMain.Loaded += WindowMain_Loaded;
            WindowMain.Closed += WindowMain_Closed;

            //выход
            miExit.Click += MiExit_Click;


            //Пользователи
            miUserAdd.Click += MiUserAdd_Click;
            miUserRemove.Click += MiUserRemove_Click;
            miUsersEdit.Click += MiUsersEdit_Click;

            //Награды
            miRewardsAdd.Click += MiRewardsAdd_Click;
            miRewardsRemove.Click += MiRewardsRemove_Click;
            miRewardsEdit.Click += MiRewardsEdit_Click;
        }



        //Константы//
        //Remove--удалить--1//
        //Edit--редактировать--2//
        //Add--добавить--3//


        #region RewardMethods
        private void MiRewardsRemove_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.RewardsState = 1;

            RewardsWindow rewards = new RewardsWindow();
            rewards.ShowDialog();
        }

        private void MiRewardsEdit_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.RewardsState = 2;

            RewardsWindow rewards = new RewardsWindow();
            rewards.ShowDialog();
        }

        private void MiRewardsAdd_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.RewardsState = 3;

            RewardsWindow rewards = new RewardsWindow();
            rewards.ShowDialog();
        }
        #endregion

        #region UsersMethods

        private void MiUserRemove_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UsersState = 1;

            UserWindow user = new UserWindow();
            user.ShowDialog();
        }

        private void MiUsersEdit_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UsersState = 2;

            UserWindow user = new UserWindow();
            user.ShowDialog();
        }

        private void MiUserAdd_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UsersState = 3;

            UserWindow user = new UserWindow();
            user.ShowDialog();
        }

        #endregion  


        public void WindowMain_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                NewUsers();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в работе БД", ex);
            }
        }

        public void NewUsers()
        {
            dgInformation.ItemsSource = RewardingBLL.UserLogic.LoadUsers().Tables[0].DefaultView;
            dgInformation.Columns[0].Visibility = Visibility.Hidden;

        }

        public void NewRewards()
        {

            dgInformation.ItemsSource = RewardingBLL.AwardLogic.LoadAwards().Tables[0].DefaultView;
            dgInformation.Columns[0].Visibility = Visibility.Hidden;

        }

        private void MiExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WindowMain_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MiUsers_Click(object sender, RoutedEventArgs e)
        {
            dgInformation.ItemsSource = RewardingBLL.UserLogic.LoadUsers().Tables[0].DefaultView;
            dgInformation.Columns[0].Visibility = Visibility.Hidden;
        }

        private void MiAward_Click(object sender, RoutedEventArgs e)
        {
            dgInformation.ItemsSource = RewardingBLL.AwardLogic.LoadAwards().Tables[0].DefaultView;
            dgInformation.Columns[0].Visibility = Visibility.Hidden;
        }
    }
}
