using patterns_pr3.Core.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.Entities
{
    public class Customer : Person
    {

        public CustomerType CustomerType { get; set; }


        public Customer(CustomerBuilder c)
        {
            Id = c.Id;
            Name = c.Name;
            Email = c.Email;
            PhoneNumber = c.PhoneNumber;
            CustomerType = c.CustomerType;
            Surname = c.Surname;
            Address = c.Address;


        }
        public override string ToString()
        {
            return $"Customer ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Surname: {Surname}\n" +
                   $"Customer Type: {CustomerType}\n" +
                   $"Email: {Email}\n" +
                   $"Phone Number: {PhoneNumber}\n" +
                   $"Address: {Address}\n";
        }
    }
    public enum CustomerType
    {
        Retailer = 1,
        Distributor,
        DirectCustomer,
        OnlineStore,
        Author,
        Other

    }
}
