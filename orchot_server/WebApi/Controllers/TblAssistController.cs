using Bll;
using Entity;
using DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblAssistController : ControllerBase
    {
        TblAssistIBLL tblAssistIBLL;
        public TblAssistController(TblAssistIBLL tblAssistIBLL)
        {
            this.tblAssistIBLL = tblAssistIBLL;
        }
        // GET: api/<TblAssistController>
        [HttpGet]
        public List<TblAssist> Get()
        {
            return tblAssistIBLL.GetAllTblAssists();
        }

        // GET api/<TblAssistController>/5
        [HttpGet("{id}")]
        public TblAssist Get(int id)
        {
            return tblAssistIBLL.GetTblAssistById(id);
        }

        // POST api/<TblAssistController>
        [HttpPost]
        public bool Post(TblAssist ta)
        {
            try
            {
                tblAssistIBLL.AddTblAssist(ta);
                return true;
            }
            catch
            {
                return false; 
            }

        }

        // PUT api/<TblAssistController>/5
        [HttpPut("{id}")]
        public bool Put(int id, TblAssist ta)
        {
            try
            {
                tblAssistIBLL.UpdateTblAssist(id, ta);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // DELETE api/<TblAssistController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                tblAssistIBLL.DeleteTblAssist(id);
                return true;

            }
            catch
            {
                return false; 
            }
        }
    }
}
