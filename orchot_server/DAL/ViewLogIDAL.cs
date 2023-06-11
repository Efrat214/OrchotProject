using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface ViewLogIDAL
    {
        List<ViewLog> GetAllViewLogs();
        ViewLog GetViewLogById(int Id);

        void AddViewLog(ViewLog v);
        void UpdateViewLog(int Id, ViewLog v);
        void DeleteViewLog(int Id);
    }
}
