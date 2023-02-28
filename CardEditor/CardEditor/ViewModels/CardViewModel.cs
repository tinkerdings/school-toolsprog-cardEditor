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
        private Card _CardData;
        public Card CardData
        {
            set
            {
                _CardData = value;
            }
            get
            {
                return _CardData;
            }
        }
        public CardViewModel() : base()
        {
            CardData = new Card();
            PropertyValidation = new PropertyValidation();
            Name = null;
            Level = null;
            Strength = null;
            Dexterity = null;
            Vitality = null;
            Energy = null;
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

        public void ResetCard()
        {
            CardData = new Card();
            Name = null;
            Level = null;
            Strength = null;
            Dexterity = null;
            Vitality = null;
            Energy = null;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Type));
            OnPropertyChanged(nameof(Level));
            OnPropertyChanged(nameof(Strength));
            OnPropertyChanged(nameof(Dexterity));
            OnPropertyChanged(nameof(Vitality));
            OnPropertyChanged(nameof(Energy));
            UpdateIsValidCard();
            UpdateIsCardDirty();
        }

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
            get => CardData.Type;
            set
            {
                CardData.Type = value;
                if(value != null)
                {
                    if(Level == null)
                    {
                        Level = CardData.Type.DefaultLevel;
                    }
                    if(Strength == null)
                    {
                       Strength = CardData.Type.DefaultStrength;
                    }
                    if(Dexterity == null)
                    {
                        Dexterity = CardData.Type.DefaultDexterity;
                    }
                    if(Vitality == null)
                    {
                        Vitality = CardData.Type.DefaultVitality;
                    }
                    if(Energy == null)
                    {
                        Energy = CardData.Type.DefaultEnergy;
                    }
                }
                OnPropertyChanged(nameof(Type));
                UpdateIsCardDirty();
            }
        }
        public string? Image
        {
            get => CardData.Image;
            set
            {
                CardData.Image = value;
                OnPropertyChanged(nameof(Image));
                UpdateIsValidCard();
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
            get => CardData.Name;
            set
            {
                string? name = PropertyValidation.ValidateString(value, 16);
                CardData.Name = name;
                OnPropertyChanged(nameof(Name));
                UpdateIsValidCard();
                UpdateIsCardDirty();
            }
        }

        public int? Level
        {
            get => CardData.Level;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 99);
                CardData.Level = val;
                OnPropertyChanged(nameof(Level));
                UpdateIsValidCard();
                UpdateIsCardDirty();
            }
        }
        public int? Strength
        {
            get => CardData.Strength;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 999);
                CardData.Strength = val;
                OnPropertyChanged(nameof(Strength));
                UpdateIsValidCard();
                UpdateIsCardDirty();
            }
        }
        public int? Dexterity
        {
            get => CardData.Dexterity;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 999);
                CardData.Dexterity = val;
                OnPropertyChanged(nameof(Dexterity));
                UpdateIsValidCard();
                UpdateIsCardDirty();
            }
        }
        public int? Vitality
        {
            get => CardData.Vitality;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 999);
                CardData.Vitality = val;
                OnPropertyChanged(nameof(Vitality));
                UpdateIsValidCard();
                UpdateIsCardDirty();
            }
        }
        public int? Energy
        {
            get => CardData.Energy;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 999);
                CardData.Energy = val;
                OnPropertyChanged(nameof(Energy));
                UpdateIsValidCard();
                UpdateIsCardDirty();
            }
        }
    }
}
