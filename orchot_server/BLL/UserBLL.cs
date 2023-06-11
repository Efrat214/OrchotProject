using Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class UserBLL : UserIBLL
    {
        UserIDAL userIDAL;

        public UserBLL(UserIDAL userIDAL)
        {
            this.userIDAL = userIDAL;
        }
        public void AddUser(User u)
        {
            userIDAL.AddUser(u);
        }

        

        public void DeleteUser(int Id)
        {
            userIDAL.DeleteUser(Id);
        }

        public List<User> GetAllUsers()
        {
            return userIDAL.GetAllUsers();
        }

        public User GetUserById(int Id)
        {
            return userIDAL.GetUserById(Id);
        }
        public User GetUserByUserName(string UserName)
        {
            return userIDAL.GetUserByUserName(UserName);
        }
        public void UpdateUser(int Id, User u)
        {
            userIDAL.UpdateUser(Id, u);
        }

       
    }
}
