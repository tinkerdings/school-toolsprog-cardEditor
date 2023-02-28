using CardEditor.Models;
using CardEditor.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.ViewModels
{
    public class CardViewModel : ViewModelBase
    {
        private PropertyValidation PropertyValidation;
        private Card CurrentCard;
        public CardViewModel() : base()
        {
            CurrentCard = new Card();
            PropertyValidation = new PropertyValidation();
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Type));
            OnPropertyChanged(nameof(Level));
            OnPropertyChanged(nameof(Strength));
            OnPropertyChanged(nameof(Dexterity));
            OnPropertyChanged(nameof(Vitality));
            OnPropertyChanged(nameof(Energy));
            UpdateIsCardDirty();
        }

        public bool CardDirty { get; set; }

        public void UpdateIsCardDirty()
        {
            CardDirty = !(
                Level == null &&
                Strength == null &&
                Dexterity == null &&
                Vitality == null &&
                Energy == null
                );
            OnPropertyChanged(nameof(CardDirty));
        }
        public CardType Type
        {
            get => CurrentCard.Type;
            set
            {
                CurrentCard.Type = value;
                if(value != null)
                {
                    if(CurrentCard.Level == null)
                    {
                        CurrentCard.Level = CurrentCard.Type.DefaultLevel;
                    }
                    if(CurrentCard.Strength == null)
                    {
                        CurrentCard.Strength = CurrentCard.Type.DefaultStrength;
                    }
                    if(CurrentCard.Dexterity == null)
                    {
                        CurrentCard.Dexterity = CurrentCard.Type.DefaultDexterity;
                    }
                    if(CurrentCard.Vitality == null)
                    {
                        CurrentCard.Vitality = CurrentCard.Type.DefaultVitality;
                    }
                    if(CurrentCard.Energy == null)
                    {
                        CurrentCard.Energy = CurrentCard.Type.DefaultEnergy;
                    }
                }
                OnPropertyChanged(nameof(Type));
                UpdateIsCardDirty();
            }
        }
        public string? Image
        {
            get => CurrentCard.Image;
            set
            {
                CurrentCard.Image = value;
                OnPropertyChanged(nameof(Image));
                UpdateIsCardDirty();
            }
        }

        public void UpdateIsValidCard()
        {
            IsValidCard = (
                Level != null &&
                Strength != null &&
                Dexterity != null &&
                Vitality != null &&
                Energy != null &&
                Type != null && 
                Name != null &&
                Image != null);
        }

        private bool _isValidCard { get; set; }
        public bool IsValidCard
        {
            get => _isValidCard;
            set
            {
                _isValidCard = value;
                OnPropertyChanged(nameof(IsValidCard));
            }
        }

        public string? Name
        {
            get => CurrentCard.Name;
            set
            {
                string? name = PropertyValidation.ValidateString(value, 16);
                CurrentCard.Name = name;
                OnPropertyChanged(nameof(Name));
                UpdateIsValidCard();
                UpdateIsCardDirty();
            }
        }

        public int? Level
        {
            get => CurrentCard.Level;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 99);
                CurrentCard.Level = val;
                OnPropertyChanged(nameof(Level));
                UpdateIsValidCard();
                UpdateIsCardDirty();
            }
        }
        public int? Strength
        {
            get => CurrentCard.Strength;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 999);
                CurrentCard.Strength = val;
                OnPropertyChanged(nameof(Strength));
                UpdateIsValidCard();
                UpdateIsCardDirty();
            }
        }
        public int? Dexterity
        {
            get => CurrentCard.Dexterity;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 999);
                CurrentCard.Dexterity = val;
                OnPropertyChanged(nameof(Dexterity));
                UpdateIsValidCard();
                UpdateIsCardDirty();
            }
        }
        public int? Vitality
        {
            get => CurrentCard.Vitality;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 999);
                CurrentCard.Vitality = val;
                OnPropertyChanged(nameof(Vitality));
                UpdateIsValidCard();
                UpdateIsCardDirty();
            }
        }
        public int? Energy
        {
            get => CurrentCard.Energy;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 999);
                CurrentCard.Energy = val;
                OnPropertyChanged(nameof(Energy));
                UpdateIsValidCard();
                UpdateIsCardDirty();
            }
        }
    }
}
