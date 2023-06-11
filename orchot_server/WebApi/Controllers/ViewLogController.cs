using Bll;
using Entity;
using DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewLogController : ControllerBase
    {
        ViewLogIBLL viewLogIBLL;
        public ViewLogController(ViewLogIBLL viewLogIBLL)
        {
            this.viewLogIBLL = viewLogIBLL;
        }
        // GET: api/<ViewLogController>
        [HttpGet]

        public List<ViewLog> Get()
        {
            return viewLogIBLL.GetAllViewLogs();
        }

        // GET api/<ViewLogController>/5
        [HttpGet("{id}")]
        public ViewLog Get(int id)
        {
            return viewLogIBLL.GetViewLogById(id);
        }

        // POST api/<ViewLogController>
        [HttpPost]
        public bool Post(ViewLog v)
        { 
            try{
                viewLogIBLL.AddViewLog(v);
                return true;

            }
            catch
            {
                return false;
            }

        }

        // PUT api/<ViewLogController>/5
        [HttpPut("{id}")]
        public bool Put(int id, ViewLog v)
        {
            try
            {
                viewLogIBLL.UpdateViewLog(id, v);
                return true;
            }
            catch
            {
                return false;

            }
        }

        // DELETE api/<ViewLogController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                viewLogIBLL.DeleteViewLog(id);
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
