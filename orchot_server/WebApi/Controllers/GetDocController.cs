using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDocController : ControllerBase
    {
        // GET: api/<GetDocController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GetDocController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GetDocController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GetDocController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GetDocController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
