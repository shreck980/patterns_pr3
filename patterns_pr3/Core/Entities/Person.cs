using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.Entities
{
    public abstract class Person: ICloneable
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }

        public virtual object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
