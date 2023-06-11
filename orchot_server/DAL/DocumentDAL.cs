using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DocumentDAL : DocumentIDAL
    {
        public OrchotDbContext db = new OrchotDbContext();
        
        public int AddDocument(Document d)
        {
            db.Documents.Add(d);
            db.SaveChanges();
            return d.Id ;  
        }

        public void DeleteDocument(int Id)
        {
            db.Documents.Remove(db.Documents.FirstOrDefault(x => x.Id == Id));
            db.SaveChanges();
        }

        public List<Document> GetAllDocuments()
        {
            List<Document> list = new List<Document>();
            foreach (var item in db.Documents.ToList())
            {
                Console.WriteLine(item.Organization);
                Console.WriteLine(item.BusinessUnit);
                Console.WriteLine(item.Department);
                Console.WriteLine(item.DocType);
                Document d = new Document();
                d.Id = item.Id;
                d.DocLink = item.DocLink;
                d.AlertActive = item.AlertActive;
                d.EffectiveDate=item.EffectiveDate;
                d.CreateDate = item.CreateDate;
                d.CreateBy = item.CreateBy;
                d.Organization = db.TblAssistValues.First(x => x.TableCode == 10 && x.Code == item.Organization).Value1;
                d.BusinessUnit = db.TblAssistValues.First(x => x.TableCode == 11 && x.Code == item.BusinessUnit).Value1;
                d.Department = db.TblAssistValues.First(x => x.TableCode == 12 && x.Code == item.Department).Value1;
                d.DocType = db.TblAssistValues.First(x => x.TableCode == 13 && x.Code == item.DocType).Value1;

                list.Add(d);
            }            
            return list;
        }

        public Document GetDocumentById(int Id)
        {
            return db.Documents.FirstOrDefault(x => x.Id == Id);
        }
        public DocReferance GetDocReferanceByDocId(int Id)
        {
            return db.DocReferances.FirstOrDefault(x => x.DocId == Id);
        }
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="d"></param>
        public void UpdateDocument(int Id, Document d)
        {
            var document = db.Documents.FirstOrDefault(x => x.Id == Id);
            if (document != null)
            {
                document.DocumentName = d.DocumentName;
                document.Organization = d.Organization;
                document.BusinessUnit = d.BusinessUnit;
                document.Department = d.Department;
                document.CreateBy = d.CreateBy;
                document.CreateDate = d.CreateDate;
                document.EffectiveDate = d.EffectiveDate;
                document.AlertActive = d.AlertActive;
                document.LastAlert = d.LastAlert;
                document.MailAddress = d.MailAddress;
                document.ExpirationDate = d.ExpirationDate;
                document.NumDaysExp = d.NumDaysExp;
                document.Deleted = d.Deleted;
                document.DocType = d.DocType;
                document.DocLink = d.DocLink;
                db.SaveChanges();
            }
        }
    }
}
