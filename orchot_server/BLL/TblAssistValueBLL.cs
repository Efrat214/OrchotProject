using Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class TblAssistValueBLL: ITblAssistValueIBLL
    {
        TblAssistValueIDAL tblAssistValueIDAL;

        public TblAssistValueBLL(TblAssistValueIDAL tblAssistValueIDAL)
        {
            this.tblAssistValueIDAL = tblAssistValueIDAL;
        }

        public void AddTblAssistValue(TblAssistValue tav)
        {
            tblAssistValueIDAL.AddTblAssistValue(tav);
        }

        public void DeleteTblAssistValue(int TableCode)
        {
            tblAssistValueIDAL.DeleteTblAssistValue(TableCode);
        }

        public List<TblAssistValue> GetAllTblAssistValues()
        {
            return tblAssistValueIDAL.GetAllTblAssistValues();
        }

        public List<TblAssistValue> GetTblAssistValueById(int TableCode)
        {
            return tblAssistValueIDAL.GetTblAssistValueById(TableCode);
        }

        public void UpdateTblAssistValue(int TableCode, TblAssistValue tav)
        {
            tblAssistValueIDAL.UpdateTblAssistValue(TableCode, tav);
        }
    }
}
