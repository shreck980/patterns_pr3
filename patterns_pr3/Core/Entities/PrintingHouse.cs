using patterns_pr3.Core.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.Entities
{
    public class PrintingHouse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public PrintingHouse(PrintingHouseBuilder builder)
        {
            Id = builder.Id;
            Name = builder.Name;
            PhoneNumber = builder.PhoneNumber;
            Address = builder.Address;
        }

        public override string ToString()
        {
            return $"Id: {Id},\nName: {Name},\nPhoneNumber: {PhoneNumber},\nAddress: {Address}";
        }

    }
}
