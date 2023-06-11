using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ViewLogDAL : ViewLogIDAL
    {
        public OrchotDbContext db = new OrchotDbContext();

        public void AddViewLog(ViewLog v)
        {
            db.ViewLogs.Add(v);
            db.SaveChanges();
        }

        public void DeleteViewLog(int Id)
        {
            db.ViewLogs.Remove(db.ViewLogs.FirstOrDefault(x => x.Id == Id));
            db.SaveChanges();
        }

        public List<ViewLog> GetAllViewLogs()
        {

            return db.ViewLogs.ToList();
        }

        public ViewLog GetViewLogById(int Id)
        {
            return db.ViewLogs.FirstOrDefault(x => x.Id == Id);
        }

        public void UpdateViewLog(int Id, ViewLog v)
        {
            var viewLog = db.ViewLogs.FirstOrDefault(x => x.Id == Id);
            if (viewLog != null)
            {
                viewLog.Id = v.Id;
                viewLog.Ip = v.Ip;
                viewLog.FullName = v.FullName;
                viewLog.ViewDate = v.ViewDate;
                viewLog.DocumentName = v.DocumentName;
                db.SaveChanges();
            }
        }

    void ViewLogIDAL.AddViewLog(ViewLog v)
    {
      throw new NotImplementedException();
    }

    void ViewLogIDAL.DeleteViewLog(int Id)
    {
      throw new NotImplementedException();
    }

    List<ViewLog> ViewLogIDAL.GetAllViewLogs()
    {
      throw new NotImplementedException();
    }

    ViewLog ViewLogIDAL.GetViewLogById(int Id)
    {
      throw new NotImplementedException();
    }

    void ViewLogIDAL.UpdateViewLog(int Id, ViewLog v)
    {
      throw new NotImplementedException();
    }
  }
}
