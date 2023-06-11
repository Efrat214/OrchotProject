using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class TblAssistDAL : TblAssistIDAL
    {
        public OrchotDbContext db = new OrchotDbContext();

        public void AddTblAssist(TblAssist ta)
        {
            db.TblAssists.Add(ta);
            db.SaveChanges();
        }

        public void DeleteTblAssist(int TableCode)
        {
            db.TblAssists.Remove(db.TblAssists.FirstOrDefault(x => x.TableCode == TableCode));
            db.SaveChanges();
        }

        public List<TblAssist> GetAllTblAssists()
        {
            return db.TblAssists.ToList();
        }

        public TblAssist GetTblAssistById(int TableCode)
        {
            return db.TblAssists.FirstOrDefault(x => x.TableCode == TableCode);

        }

        public void UpdateTblAssist(int TableCode, TblAssist ta)
        {
            var tblAssist = db.TblAssists.FirstOrDefault(x => x.TableCode == TableCode);
            if (tblAssist != null)
            {
                tblAssist.TableCode = ta.TableCode;
                tblAssist.TableName = ta.TableName;
                tblAssist.TableDescription = ta.TableDescription;
                db.SaveChanges();
            }
        }
    }
}
