using Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public interface DocReferanceIBLL
    {
        List<DocReferance> GetAllDocReferances();
        DocReferance GetDocReferanceById(int Id);
        List<DocReferance> GetDocReferanceByDocId(int Id);

        void AddDocReferance(DocReferance d);
        void UpdateDocReferance(int Id, DocReferance d);
        void DeleteDocReferance(int Id);
    }
}
