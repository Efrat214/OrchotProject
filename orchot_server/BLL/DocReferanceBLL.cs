using Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class DocReferanceBLL : DocReferanceIBLL
    {
        DocReferanceIDAL docReferanceIDAL;


        public DocReferanceBLL(DocReferanceIDAL docReferanceIDAL)
        {
            this.docReferanceIDAL = docReferanceIDAL;
        }

        public void AddDocReferance(DocReferance d)
        {
            docReferanceIDAL.AddDocReferance(d);
        }

       

        public void DeleteDocReferance(int Id)
        {
            docReferanceIDAL.DeleteDocReferance(Id);
        }

        public List<DocReferance> GetAllDocReferances()
        {
            return docReferanceIDAL.GetAllDocReferances();
        }

        public List<DocReferance> GetDocReferanceByDocId(int Id)
        {
            return docReferanceIDAL.GetDocReferanceByDocId(Id);
        }

        public DocReferance GetDocReferanceById(int Id)
        {
            return docReferanceIDAL.GetDocReferanceById(Id);
        }
        

        public void UpdateDocReferance(int Id, DocReferance d)
        {
            docReferanceIDAL.UpdateDocReferance(Id, d);
        }


       
    }
}
