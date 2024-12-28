using Bogus;
using patterns_pr3.Core.Builder;
using patterns_pr3.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.FakeDataGenerators
{
    public class AuthorDataGenerator : IFakeDataGenerator<Author>
    {
        Faker<AuthorBuilder> authorModel;
        Faker<Address> addressModel;
        public Author GetFakeData()
        {
            authorModel = new Faker<AuthorBuilder>()

            .RuleFor(u => u.Name, f => f.Name.FirstName())
            .RuleFor(u => u.Surname, f => f.Name.LastName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumberFormat())

            .RuleFor(u => u.Pseudonym, f => f.Name.FirstName() + " " + f.Name.LastName());

            addressModel = new Faker<Address>()

           .RuleFor(u => u.Country, f => f.Address.Country())
           .RuleFor(u => u.City, f => f.Address.City())
           .RuleFor(u => u.Street, f => f.Address.StreetName())
           .RuleFor(u => u.House, f => f.Random.Int(1, 500))
           .RuleFor(u => u.Apartment, f => f.Random.Bool() ? f.Random.Int(1, 200) : 0);

            var fakeAuthor = authorModel.Generate();
            var fakeAddress = addressModel.Generate();


            return fakeAuthor
            .SetCountry(fakeAddress.Country)
            .SetCity(fakeAddress.City)
            .SetStreet(fakeAddress.Street)
            .SetHouse(fakeAddress.House)
            .SetAppartment(fakeAddress.Apartment.Value).Build();
        }
    }
}
