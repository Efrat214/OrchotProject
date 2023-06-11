using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class UserDAL : UserIDAL
    {
        public OrchotDbContext db = new OrchotDbContext();

        public void AddUser(User u)
        {

            db.Users.Add(u);
            db.SaveChanges();
        }

        public void DeleteUser(int Id)
        {
            db.Users.Remove(db.Users.FirstOrDefault(x => x.Id == Id));
            db.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            foreach (var item in db.Users.ToList())
            {
                User u = new User();
                u.Id = item.Id;
                u.FullName = item.FullName;
                u.MailAddress = item.MailAddress;
                u.Admin=item.Admin;
                u.Active=item.Active;
                u.Mobile=item.Mobile;
                u.UserName=item.UserName;
                u.Password=item.Password;
                var departmentValue = db.TblAssistValues.FirstOrDefault(x => x.TableCode == 12 && x.Code == item.Department);
                u.Department = departmentValue != null ? departmentValue.Value1 : null;

            //    u.Department = db.TblAssistValues.First(x => x.TableCode == 12 && x.Code == item.Department).Value1;
          users.Add(u);
            }
            return users;

        }

        public User GetUserById(int Id)
        {
            try
            {
                return db.Users.FirstOrDefault(x => x.Id == Id);

            }
            catch
            {
                return null;
            }

        }
        public User GetUserByUserName(string UserName)
        {

            return db.Users.FirstOrDefault(x => x.UserName == UserName);
                

           
        }
        public void UpdateUser(int Id, User u)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == Id);
            if (user != null)
            {
                user.Id = u.Id;
                user.FullName = u.FullName;
                user.UserName = u.UserName;
                user.MailAddress = u.MailAddress;
                user.Password = u.Password;
                user.Department = u.Department;
                user.Mobile = u.Mobile;
                user.Admin = u.Admin;
                user.Active = u.Active;
                db.SaveChanges();
            }
        }
    }
}
