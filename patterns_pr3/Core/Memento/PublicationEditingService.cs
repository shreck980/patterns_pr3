using patterns_pr3.Core.Builder;
using patterns_pr3.Core.Entities;

namespace patterns_pr3.Core.Memento
{
    public class PublicationEditingService
    {
        private readonly PublicationCaretaker _caretaker;

        /*public PublicationEditingService()
        {
            _caretaker = new PublicationCaretaker(null);
        }

        public Publication RestoreState()
        {
            _caretaker.Undo();
            Publication p = new Publication(new PublicationBuilder());
            p.RestoreState( _caretaker.GetCurrentState());
            return p;
        }

        public string SaveState(Publication p)
        {
            return _caretaker.Save(p);
        }*/

    }
}
