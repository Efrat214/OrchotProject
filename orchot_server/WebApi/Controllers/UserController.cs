using Bll;
using Entity;
using DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserIBLL userIBLL;
        public UserController(UserIBLL userIBLL)
        {
            this.userIBLL = userIBLL;
        }
        // GET: api/<UserController>
        [HttpGet]
        public List<User> Get()
        {
            return userIBLL.GetAllUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return userIBLL.GetUserById(id);
        }

        //[HttpGet("{name}")]
        //public User Get(string name)
        //{
        //    return userIBLL.GetUserByUserName(name);
        //}
        // [HttpGet("{name}")]
        //public User GetUserByUserName(string name)
        //{
        //    return userIBLL.GetUserByName(name);
        //}

        // POST api/<UserController>
        [HttpPost]
        public Boolean Post(User u)
        {
            try
            {
                 userIBLL.AddUser(u);
                return true;
            }
            catch {
                return false;
            }


       
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public bool Put(int id, User u)
        {
            try
            {
                userIBLL.UpdateUser(id, u);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                userIBLL.DeleteUser(id);
                return true;
            }
            catch
            {
                return false;

            }
        }
        
    }
}
