using patterns_pr3.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.Builder
{
    public class AuthorBuilder : PersonBuilder<AuthorBuilder>
    {


        public string Pseudonym { get; private set; }

        public AuthorBuilder()
        {
            Id = 0;
            Address = new Address();
        }



        public AuthorBuilder SetPseudonym(string pseudonym)
        {
            Pseudonym = pseudonym;
            return this;
        }


        public Author Build()
        {
            return new Author(this);
        }

        public void Reset()
        {
            Address = new Address();
            Id = 0;
            Name = null;
            Surname = string.Empty;

            Email = string.Empty;
            PhoneNumber = string.Empty;
            Pseudonym = string.Empty;
        }
    }

}
