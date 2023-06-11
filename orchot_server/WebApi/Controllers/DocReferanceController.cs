using DAL;
using Bll;
using Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocReferanceController : ControllerBase
    {
        DocReferanceIBLL docReferanceIBLL;
        public DocReferanceController(DocReferanceIBLL docReferanceIBLL)
        {
            this.docReferanceIBLL = docReferanceIBLL;
        }
        // GET: api/<DocReferanceController>
        [HttpGet]
        public List<DocReferance> Get()
        {
            return docReferanceIBLL.GetAllDocReferances();
        }

        // GET api/<DocReferanceController>/5
        [HttpGet("{id}")]
        public DocReferance Get(int id)
        {
            return docReferanceIBLL.GetDocReferanceById(id);
        }

        // POST api/<DocReferanceController>
        [HttpPost]
        public bool Post(DocReferance d)
        {
            try
            {
                docReferanceIBLL.AddDocReferance(d);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        // PUT api/<DocReferanceController>/5
        [HttpPut("{id}")]
        public bool Put(int id, DocReferance d)
        {
            try
            {
                docReferanceIBLL.UpdateDocReferance(id, d);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // DELETE api/<DocReferanceController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                docReferanceIBLL.DeleteDocReferance(id);
                return true;

           }
            catch
            {
                return false;
            }
        }
    }
}
