using atm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm.Repository
{
  public  class UserReppository
    {
        public List<User> GetAll()
        {
            return new List<User>
{
new User
{
Number =2222,
Fullname="User1",
Balance=2000
},
new User
{
Number=7777,
Fullname="User2",
Balance=200
},
new User
{
Number=3333,
Fullname="User3",
Balance=20
}
};
        }
    }
}
