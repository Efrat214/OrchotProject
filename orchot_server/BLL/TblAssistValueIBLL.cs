using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public interface ITblAssistValueIBLL
    {
        List<TblAssistValue> GetAllTblAssistValues();
        List<TblAssistValue> GetTblAssistValueById(int TableCode);

        void AddTblAssistValue(TblAssistValue tav);
        void UpdateTblAssistValue(int TableCode, TblAssistValue tav);
        void DeleteTblAssistValue(int TableCode);
    }
}
