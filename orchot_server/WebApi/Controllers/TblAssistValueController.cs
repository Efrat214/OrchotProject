using Bll;
using Entity;
using DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblAssistValueController : ControllerBase
    {
        ITblAssistValueIBLL tblAssistValueIBLL;
        public TblAssistValueController(ITblAssistValueIBLL tblAssistValueIBLL)
        {
            this.tblAssistValueIBLL = tblAssistValueIBLL;
        }
        // GET: api/<TblAssistValueController>
        [HttpGet]
        public List<TblAssistValue> Get()
        {
            return tblAssistValueIBLL.GetAllTblAssistValues();
        }

        // GET api/<TblAssistValueController>/5
        [HttpGet("{id}")]
        public List<TblAssistValue> Get(int id)
        {
            return tblAssistValueIBLL.GetTblAssistValueById(id);
        }

        // POST api/<TblAssistValueController>
        [HttpPost]
        public bool Post(TblAssistValue tav)
        {
            try
            {
                tblAssistValueIBLL.AddTblAssistValue(tav);
                return true;
            }
            catch
            {
                return false;

            }
        }

        // PUT api/<TblAssistValueController>/5
        [HttpPut("{id}")]
        public bool Put(int id, TblAssistValue tav)
        {
            try
            {
                tblAssistValueIBLL.UpdateTblAssistValue(id, tav);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // DELETE api/<TblAssistValueController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                tblAssistValueIBLL.DeleteTblAssistValue(id);
                return true;

            }
            catch
            {
                return false;
            }

        }
    }
}
