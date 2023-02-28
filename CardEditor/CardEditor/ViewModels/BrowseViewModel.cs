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
        public ObservableCollection<Card> ObservableCards
        {
            get => Database.ObservableCards;
        }

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

        public void Update()
        {
            OnPropertyChanged(nameof(ObservableCards));
        }

        public ViewModelLocator ViewModelLocator { get; set; }

        public event Action SelectedCardChanged;
        private Card? _SelectedCard;
        public BrowseViewModel()
        {
            ViewModelLocator = new ViewModelLocator();
            SelectedCardChanged += SelectedCardChangedCallback;
        }

        private void SelectedCardChangedCallback()
        {
            OnPropertyChanged(nameof(SelectedCard));
            if(SelectedCard != null)
            {
                ViewModelLocator.EditViewModel.SetCard(SelectedCard);
            }
        }
    }
}
