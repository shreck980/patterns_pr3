using NuGet.Packaging.Signing;
using patterns_pr3.Core.Entities;

namespace patterns_pr3.Core.Memento
{
    public class PublicationMemento
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int Circulation { get; set; }
        public decimal Price { get; set; }
        public Genre Genre { get; set; }
        public PrintQuality PrintQuality { get; set; }
        public int Quantity { get; set; }
        public List<Author> Authors { get; set; }

        public PublicationMemento()
        {
            Id = 0;
            Title = "";
            PageCount = 0;
            Circulation = 0; Price = 0;
            Genre = Genre.Fiction;
            PrintQuality =  PrintQuality.Low;
            Authors = new List<Author>();
        }
            public PublicationMemento(long id,string title, int pageCount, int circulation, decimal price, int quantity, List<Author> authors)
            {
            Id = id;
            Title = title;
            PageCount = pageCount;
            Circulation = circulation;
            Price = price;
            Quantity = quantity;
            Authors = authors;
        }

        public override string ToString()
        {
            string authors = Authors != null && Authors.Count > 0
                ? string.Join(", ", Authors.Select(a => a.Name))
                : "No authors";

            return $"Id: {Id}, Title: {Title}, PageCount: {PageCount}, Circulation: {Circulation}, " +
                   $"Price: {Price:C}";
        }



    }
}
