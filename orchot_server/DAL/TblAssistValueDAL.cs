using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class TblAssistValueDAL : TblAssistValueIDAL
    {
        public OrchotDbContext db = new OrchotDbContext();

        public void AddTblAssistValue(TblAssistValue tav)
        {
            db.TblAssistValues.Add(tav);
            db.SaveChanges();
        }

        public void DeleteTblAssistValue(int TableCode)
        {
            db.TblAssistValues.Remove(db.TblAssistValues.FirstOrDefault(x => x.TableCode == TableCode));
            db.SaveChanges();
        }

        public List<TblAssistValue> GetAllTblAssistValues()
        {
            return db.TblAssistValues.ToList();
        }

        public List<TblAssistValue> GetTblAssistValueById(int TableCode)
        {
            return db.TblAssistValues.Where(x => x.TableCode == TableCode).ToList();
        }

        public void UpdateTblAssistValue(int TableCode, TblAssistValue tav)
        {
            var tblAssistValue = db.TblAssistValues.FirstOrDefault(x => x.TableCode == TableCode);
            if (tblAssistValue != null)
            {
                tblAssistValue.TableCode = tav.TableCode;
                tblAssistValue.Code = tav.Code;
                tblAssistValue.Value1 = tav.Value1;
                tblAssistValue.Active = tav.Active;
                db.SaveChanges();
            }
        }
    }

}
