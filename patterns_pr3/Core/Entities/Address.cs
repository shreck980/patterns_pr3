using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.Entities
{
    public class Address : ICloneable
    {
        public long Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int? Apartment { get; set; }


        public Address()
        {
            House = 0;
            Apartment = 0;
        }

        public override string ToString()
        {
            return $"{Street} {House}" +
                   (Apartment.HasValue ? $", Apt {Apartment.Value}" : "") +
                   $", {City}, {Country}";
        }

        public object Clone()
        {
            
            return new Address
            {
                Id = this.Id,
                Country = this.Country,
                City = this.City,
                Street = this.Street,
                House = this.House,
                Apartment = this.Apartment
            };
        }
    }
}
