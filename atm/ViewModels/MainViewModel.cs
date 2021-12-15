using atm.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using atm.Repository;
using System.Windows.Threading;
using System.Threading;
namespace atm.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public RelayCommand LoadDataButton { get; set; }
        public RelayCommand TransferMoneyButton { get; set; }
        //public MainWindow main { get; set; }
        public static object obj = new object();
        DispatcherTimer dispatcher = new DispatcherTimer();
        public UserReppository  repository { get; set; }
        public User User { get; set; }
        public MainViewModel(MainWindow mainWindow) {

            Users = new List<User>();
            repository = new UserReppository();
            Users = repository.GetAll();
            TransferMoneyButton = new RelayCommand((sender) =>
            {
                lock (obj)
                {
                    dispatcher.Start();
                    if (User.Balance >= decimal.Parse(mainWindow.transfer .Text))
                    {
                        MessageBox.Show("Please wait for the operation to be performed");
                        Thread.Sleep(5000);
                        decimal price=User.Balance - decimal.Parse(mainWindow.transfer .Text );
                        User.Balance = price;
                        mainWindow.price .Content = User.Balance;
                        MessageBox.Show("The money ransfer was successful");
                    }
                    else
                    {
                        MessageBox.Show("There is not enough money in the balance. The operation was not performed");
                    }
                }
            });
            LoadDataButton = new RelayCommand((sender) =>
            {
                foreach (var item in Users)
                {
                    if (item.Number .ToString () == mainWindow.insertlbl .Text)
                    {

                        mainWindow.name .Content = item.Fullname ;
                        mainWindow.balance.Content = item.Balance;
                        User = item;
                        mainWindow.price.Visibility = Visibility.Visible;
                        mainWindow.price2.Visibility = Visibility.Visible;
                        mainWindow.transfer2.Visibility = Visibility.Visible;
                        mainWindow.transfer .Visibility = Visibility.Visible;
                        mainWindow.cardnumber .Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("This User is not available try again");
                    }
                }
            });
        }
        private List<User> allUsers;
        public List<User> Users
        {
            get { return allUsers; }
            set { allUsers = value; OnPropertyChanged(); }
        }
        private User selectedUser;
        public User SelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value; OnPropertyChanged(); }
        }
        }
    }
