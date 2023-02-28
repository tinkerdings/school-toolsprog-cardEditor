using CardEditor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.ViewModels
{
    public class BrowseViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Card> _cards;
        public IEnumerable<Card> Cards => _cards;

        public Card? SelectedCard
        {
            get
            {
                return _SelectedCard;
            }
            set
            {
                _SelectedCard = value;
                SelectedCardChanged?.Invoke();
            }
        }

        public event Action SelectedCardChanged;
        private Card? _SelectedCard;
        public BrowseViewModel()
        {
            _cards = new ObservableCollection<Card>();
            _cards.CollectionChanged += CardCollectionChanged;
            var allCards = Database.LoadRecords<Card>();
            foreach (var card in allCards)
            {
                _cards.Add(card);
            }
            SelectedCardChanged += SelectedCardChangedCallback;
        }

        private void SelectedCardChangedCallback()
        {
            OnPropertyChanged(nameof(SelectedCard));
        }

        public void CardCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Cards));
        }
    }
}
