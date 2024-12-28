using patterns_pr3.Core.Entities;
using patterns_pr3.Core.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.DAO
{
    public interface IAuthorDAO : ISubject
    {

        void AddAuthor(Author p);

        Author GetAuthor(int id);
        Author GetAuthorByName(string name, string surname);
        List<Author> GetAuthorByPublicationId(long publId);
        void AddAuthorsToPublication(Publication p);
        void UpdateAuthor(Author a);

    }
}
