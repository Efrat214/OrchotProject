 using Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class ViewLogBLL : ViewLogIBLL
    {
        ViewLogIDAL viewLogIDAL;

        public ViewLogBLL(ViewLogIDAL viewLogIDAL)
        {
            this.viewLogIDAL = viewLogIDAL;
        }

        public void AddViewLog(ViewLog v)
        {
            viewLogIDAL.AddViewLog(v);
        }

       

        public void DeleteViewLog(int Id)
        {
            viewLogIDAL.DeleteViewLog(Id);
        }

        public List<ViewLog> GetAllViewLogs()
        {
            return viewLogIDAL.GetAllViewLogs();
        }

        public ViewLog GetViewLogById(int Id)
        {
            return viewLogIDAL.GetViewLogById(Id);
        }

        public void UpdateViewLog(int Id, ViewLog v)
        {
            viewLogIDAL.UpdateViewLog(Id, v);
        }

       

        

        
    }
}
