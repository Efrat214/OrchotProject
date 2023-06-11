using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface DocReferanceIDAL
    {
        
            List<DocReferance> GetAllDocReferances();
            DocReferance GetDocReferanceById(int Id);

        List<DocReferance> GetDocReferanceByDocId(int Id);


            int AddDocReferance(DocReferance d);
            void UpdateDocReferance(int Id, DocReferance d);
            void DeleteDocReferance(int Id);

           


    }
}
