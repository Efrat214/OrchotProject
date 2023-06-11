
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public interface UserIBLL
    {
        List<User> GetAllUsers();
        User GetUserById(int Id);
        User GetUserByUserName(string UserName);
        void AddUser(User u);
        void UpdateUser(int Id, User u);
        void DeleteUser(int Id);
    }
}
