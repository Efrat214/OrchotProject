using Entity;
using Bll;
using Dal;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtController : ControllerBase
    {

        UserIBLL userIBLL;
        public ExtController(UserIBLL userIBLL)
        {
            this.userIBLL = userIBLL;
        }
        // GET: api/<ExtController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ExtController>/5
        [HttpGet("{name}")]
        public User Get(string name)
        {
            return userIBLL.GetUserByUserName(name);
        }

        // POST api/<ExtController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExtController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExtController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
