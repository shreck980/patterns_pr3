using patterns_pr3.Core.Entities;

namespace patterns_pr3.Core.Memento
{
    public class PublicationCaretaker
    {

        private List<PublicationMemento> _history = new List<PublicationMemento>();
        private int _index = -1;  
        private bool _isDeleted = false;

       
        public PublicationMemento Previous()
        {
            if (_isDeleted)
            {
                throw new Exception("Об'єкт видалено. Попередня версія недоступна.");
            }

            if (_index > 0)
            {
                _index--; 
                return _history[_index]; 
            }
            else if(_index == 0)
            {
                return _history[_index];
            }
            else
            {
                return null; 
            }
        }

        
        public string Save(PublicationMemento memento)
        {
            if (_isDeleted)
            {
                _isDeleted = false;
            }

            
            if (_index < _history.Count - 1)
            {
                _history.RemoveRange(_index + 1, _history.Count - _index - 1);
            }

            _history.Add(memento);
            _index = _history.Count - 1; 
            return $"Стан збережено: {memento}";
        }

       
        public PublicationMemento GetCurrentState()
        {
            if (_index >= 0)
            {
                return _history[_index];
            }
            return null; 
        }


        public PublicationMemento Next()
        {
            if (_isDeleted)
            {
                throw new Exception("Об'єкт видалено. Наступна версія недоступна.");
            }

            if (_index < _history.Count - 1)
            {
                _index++;
                return _history[_index];
            }
            if (_index == _history.Count - 1)
            {

                return _history[_index];
            }
            return null;
        }

        
        public string DeletePublication()
        {
            _isDeleted = true;
            _index = -1;
            _history.Clear();
            return "Об'єкт видалено.";
        }

    }
}
