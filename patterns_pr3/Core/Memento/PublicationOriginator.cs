using patterns_pr3.Core.Entities;

namespace patterns_pr3.Core.Memento
{
    public class PublicationOriginator
    {


        private string _title;
        private long _id;
        private int _pageCount;
        private int _circulation;
        private decimal _price;
        private int _quantity;
        private List<Author> _authors;

        public PublicationOriginator(long id,string title, int pageCount, int circulation, decimal price, int quantity, List<Author> authors)
        {
            _id = id;
            _title = title;
            _pageCount = pageCount;
            _circulation = circulation;
            _price = price;
            _quantity = quantity;
            _authors = new List<Author>(authors.Select(author => (Author)author.Clone())); 
        }

     
       
        public PublicationMemento SaveToMemento()
        {
            return new PublicationMemento(_id,_title, _pageCount, _circulation, _price, _quantity, _authors);
        }

     
        public void RestoreFromMemento(PublicationMemento memento)
        {
            _id = memento.Id;
            _title = memento.Title;
            _pageCount = memento.PageCount;
            _circulation = memento.Circulation;
            _price = memento.Price;
            _quantity = memento.Quantity;

          
            _authors = new List<Author>(memento.Authors.Select(author => (Author)author.Clone()));
        }

      
        public void UpdateTitle(string title) => _title = title;
        public void UpdatePageCount(int pageCount) => _pageCount = pageCount;
        public void UpdateCirculation(int circulation) => _circulation = circulation;
        public void UpdatePrice(decimal price) => _price = price;
        public void UpdateQuantity(int quantity) => _quantity = quantity;
        public void UpdateAuthors(List<Author> authors)
        {
            _authors = new List<Author>(authors.Select(author => (Author)author.Clone())); 
        }

    }
}
