using atm.Commands;
using at36666666m.Repository;
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

        public RelayCommand InsertButton { get; set; }
        public RelayCommand LoadDataButton { get; set; }
        public RelayCommand TransferMoneyButton { get; set; }
        public RelayCommand NameLbl { get; set; }
        public RelayCommand BalanceLbl { get; set; }
        public MainWindow main { get; set; }
        public static object obj = new object();

        public RelayCommand PriceLbl { get; set; }
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
                    if (decimal.Parse(User.Balance.ToString()) >= decimal.Parse(main.transfer .Text))
                    {
                        Thread.Sleep(5000);
                        User.Balance = (decimal.Parse(User.Balance.ToString()) - decimal.Parse(main.transfer .Text .ToString ()).ToString ();
                        main.balance.Content = User.Balance;
                    }
                    else
                    {
                        MessageBox.Show("Transfer Declined");
                    }
                }
            });
             InsertButton = new RelayCommand((sender) =>
             {
                 main.insertlbl  .Visibility = Visibility.Visible;
             });
            LoadDataButton = new RelayCommand((sender) =>
            {
                foreach (var item in Users)
                {
                    if (item.Number .ToString () == main.insertlbl .Text)
                    {
                        main.name .Content = item.Fullname ;
                        main.balance.Content = item.Balance;
                        User = item;
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


