using Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class DocumentBLL : DocumentIBLL
    {
        DocumentIDAL documentIDAL;
        DocReferanceIDAL doR;

        public DocumentBLL(DocumentIDAL documentIDAL, DocReferanceIDAL docReferanceIDAL)
        {
            this.documentIDAL = documentIDAL;
            this.doR = docReferanceIDAL;
        }

        public object listGetDocWithDocRef()
        {
            var x = (from d in this.documentIDAL.GetAllDocuments()
                     join dr in this.doR.GetAllDocReferances() on d.Id equals dr.DocId
                     select new { docId = d.Id, }).ToList();

            return x; 
        }
        public int AddDocument(Document d)
        {
            return documentIDAL.AddDocument(d);
        }

       

        public void DeleteDocument(int Id)
        {
            documentIDAL.DeleteDocument(Id);
        }

        public List<Document> GetAllDocuments()
        {
            return documentIDAL.GetAllDocuments();
        }

        public Document GetDocumentById(int Id)
        {
            return documentIDAL.GetDocumentById(Id);
        }

        public void UpdateDocument(int Id, Document d)
        {
            documentIDAL.UpdateDocument(Id, d);
        }

        
    }
}
