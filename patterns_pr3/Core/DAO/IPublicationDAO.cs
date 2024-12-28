using patterns_pr3.Core.Entities;
using patterns_pr3.Core.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.DAO
{
    public interface IPublicationDAO : ISubject
    {
        void AddPublication(Publication p);
        Publication GetPublication(int id);
        List<Publication> GetPublicationByAuthorId(int authorId);
        List<Publication> GetPublicationByOrderId(int orderId);
        List<Publication> GetPublicationByCustomerId(int customerId);
        List<Publication> GetPublicationByTitle(string title);
        void UpdatePublication(Publication p);



    }
}
