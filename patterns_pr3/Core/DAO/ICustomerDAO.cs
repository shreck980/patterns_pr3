using patterns_pr3.Core.Entities;
using patterns_pr3.Core.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.DAO
{
    public interface ICustomerDAO : ISubject
    {
        void AddCustomer(Customer p);
        Customer GetCustomer(int id);
        Customer GetCustomerByName(string name, string surname);
        List<Customer> GetCustomerByCountry(string country);
        void UpdateCustomer(Customer a);
    }
}
