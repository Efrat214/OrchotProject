using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public interface TblAssistIBLL
    {
        List<TblAssist> GetAllTblAssists();
        TblAssist GetTblAssistById(int TableCode);

        void AddTblAssist(TblAssist ta);
        void UpdateTblAssist(int TableCode, TblAssist ta);
        void DeleteTblAssist(int TableCode);
    }
}
