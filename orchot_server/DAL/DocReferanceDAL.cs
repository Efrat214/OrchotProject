//using Entity;
using System;
using Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DocReferanceDAL : DocReferanceIDAL
    {
        public OrchotDbContext db = new OrchotDbContext();
        
        public int AddDocReferance(DocReferance d)
        {
            db.DocReferances.Add(d);
            db.SaveChanges();
            return d.Id;
        }

        public void DeleteDocReferance(int Id)
        {
            db.DocReferances.Remove(db.DocReferances.FirstOrDefault(x => x.Id == Id));
            db.SaveChanges();
        }

        public List<DocReferance> GetAllDocReferances()
        {
           

            return db.DocReferances.ToList();
        }



      
        public List<DocReferance> GetDocReferanceByDocId(int Id)
        {
            return db.DocReferances.Where(x=>x.DocId==Id).ToList();
        }

        public DocReferance GetDocReferanceById(int Id)
        {
            return db.DocReferances.FirstOrDefault(x => x.Id == Id);
        }

        public void UpdateDocReferance(int Id, DocReferance d)
        {
            var docReferance = db.DocReferances.FirstOrDefault(x => x.Id == Id);
            if (docReferance != null)
            {
                docReferance.DocId = d.DocId;
                docReferance.RefType = d.RefType;
                docReferance.Ref = d.Ref;
                db.SaveChanges();
            }
        }

      
    }
}
