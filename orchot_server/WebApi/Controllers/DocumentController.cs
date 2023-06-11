using Bll;
using Entity;
using DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        DocumentIBLL documentIBLL;
        //CreditsDBContext context = new CreditsDBContext();
        public DocumentController(DocumentIBLL documentIBLL)
        {
            this.documentIBLL = documentIBLL;
        }
        // GET: api/<DocumentController>
        [HttpGet]
        public List<Document> Get()
        {
            return documentIBLL.GetAllDocuments();
        }

        // GET api/<DocumentController>/5
        [HttpGet("{id}")]
        public Document Get(int id)
        {
            return documentIBLL.GetDocumentById(id);
        }

        // POST api/<DocumentController>
        [HttpPost]
        public int Post(Document d)
        {
            try
            {
                return documentIBLL.AddDocument(d);
                
            }
                catch
                {
                    return 0;
                }
        }

        // PUT api/<DocumentController>/5
        [HttpPut("{id}")]
        public bool Put(int id, Document d)
        {
            try
            {
                documentIBLL.UpdateDocument(id, d);
                return true;
            }
            catch
            {
                return false;
            }

        }

        // DELETE api/<DocumentController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                documentIBLL.DeleteDocument(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
