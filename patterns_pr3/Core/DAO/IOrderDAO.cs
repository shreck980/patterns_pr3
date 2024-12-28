using patterns_pr3.Core.Entities;
using patterns_pr3.Core.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.DAO
{
    public interface IOrderDAO : ISubject
    {

        void AddOrder(Order o);
        void UpdateOrder(Order o);
        void UpdateOrderPublication(Order o);
        Order GetOrder(long id);
        List<Order> GetOrderbyDate(DateTime date);
        List<Order> GetOrderbyCustomer(long custoemrId);
        List<Order> GetOrderbyStatus(OrderStatus status);
    }
}
