using Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class TblAssistBLL : TblAssistIBLL
    {
        TblAssistIDAL tblAssistIDAL;


        public TblAssistBLL(TblAssistIDAL tblAssistIDAL)
        {
            this.tblAssistIDAL = tblAssistIDAL;
        }
        public void AddTblAssist(TblAssist ta)
        {
            tblAssistIDAL.AddTblAssist(ta);
        }

       

        public void DeleteTblAssist(int TableCode)
        {
            tblAssistIDAL.DeleteTblAssist(TableCode);
        }

        public List<TblAssist> GetAllTblAssists()
        {
           return tblAssistIDAL.GetAllTblAssists();
        }

        public TblAssist GetTblAssistById(int TableCode)
        {
            return tblAssistIDAL.GetTblAssistById(TableCode);
        }

        public void UpdateTblAssist(int TableCode, TblAssist ta)
        {
            tblAssistIDAL.UpdateTblAssist(TableCode, ta);
        }

        
    }
}
