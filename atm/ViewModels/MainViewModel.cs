using atm.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.ViewModels
{
 \
    public class MainViewModel : BaseViewModel
    {
        public RelayCommand InsertButton { get; set; }
        public RelayCommand LoadDataButton { get; set; }
        public RelayCommand TransferMoneyButton { get; set; }
        public RelayCommand NameLbl { get; set; }
        public RelayCommand BalanceLbl { get; set; }
        public MainWindow main { get; set; }
        public RelayCommand PriceLbl { get; set; }
        public MainViewModel(MainWindow mainWindow) { 
        TransferMoneyButton = new RelayCommand((sender) =>
            {
        
            
            });
             InsertButton = new RelayCommand((sender) =>
             {
                 Users.Add ()
        });
            LoadDataButton = new RelayCommand((sender) =>
            {
                foreach (var item in Users)
                {
                    if(item.Number==main.insertlbl .to)
                    {

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


