using patterns_pr3.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.Builder
{
    public class CustomerBuilder : PersonBuilder<CustomerBuilder>
    {

        public CustomerType CustomerType { get; private set; }

        public CustomerBuilder()
        {

            Address = new Address();
            CustomerType = CustomerType.Other;
            Id = 0;
        }



        public CustomerBuilder SetCustomerType(CustomerType customerType)
        {
            CustomerType = customerType;
            return this;
        }


        public Customer Build()
        {
            return new Customer(this);
        }

        public void Reset()
        {
            Address = new Address();
            Id = 0;
            Name = null;
            Surname = string.Empty;

            Email = string.Empty;
            PhoneNumber = string.Empty;
            CustomerType = CustomerType.Other;
        }
    }
}
