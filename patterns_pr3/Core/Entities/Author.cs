using patterns_pr3.Core.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.Entities
{
    public class Author : Person
    {

        public string Pseudonym { get; set; }


        public Author(AuthorBuilder AuthorBuilder)
        {
            Id = AuthorBuilder.Id;
            Name = AuthorBuilder.Name;
            Surname = AuthorBuilder.Surname;
            Email = AuthorBuilder.Email;
            PhoneNumber = AuthorBuilder.PhoneNumber;
            Address = AuthorBuilder.Address;
            Pseudonym = AuthorBuilder.Pseudonym;
        }


        public override string ToString()
        {
            return $"Author: {Name} {Surname} (Pseudonym: {Pseudonym})\n" +
                   $"Email: {Email}\n" +
                   $"Phone Number: {PhoneNumber}\n" +
                   $"Address: {Address}";
        }

        public override object Clone()
        {
          
            Author clonedAuthor = (Author)this.MemberwiseClone();

          
            if (this.Address != null)
            {
                clonedAuthor.Address = (Address)this.Address.Clone();
            }

        
            return clonedAuthor;
        }

    }


}
