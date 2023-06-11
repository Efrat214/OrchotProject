using Bll;
using Microsoft.AspNetCore.Mvc;
using Entity;
using Dal;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtraController : ControllerBase
    {
        DocReferanceIBLL docReferanceIBLL;
        public ExtraController(DocReferanceIBLL docReferanceIBLL)
        {
            this.docReferanceIBLL = docReferanceIBLL;
        }
        // GET: api/<ExtraController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ExtraController>/5
        [HttpGet("{docid}")]
        public List<DocReferance> Get(int docid)
        {
            return docReferanceIBLL.GetDocReferanceByDocId(docid);
        }

        // POST api/<ExtraController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExtraController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExtraController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
