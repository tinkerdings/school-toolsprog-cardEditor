using CardEditor.Models;
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
        private Card CurrentCard;
        public CardViewModel()
        {
            CurrentCard = new Card();
        }

        public string Name
        {
            get => CurrentCard.Name;
            set
            {
                CurrentCard.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public CardType Type
        {
            get => CurrentCard.Type;
            set
            {
                CurrentCard.Type = value;
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
                OnPropertyChanged(nameof(Type));
            }
        }
        public string? Image
        {
            get => CurrentCard.Image;
            set
            {
                CurrentCard.Image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        private int? ValidateInt(IComparable? val, int lowerBound, int upperBound)
        {
            if(val == null) return null;
            if(val.GetType() != typeof(int)) { return null; }
            if(val.CompareTo(lowerBound) < 0) { return lowerBound; }
            if(val.CompareTo(upperBound) > 0) { return upperBound; }
            return (int)val;
        }

        private void UpdateIsValidCard()
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

        public int? Level
        {
            get => CurrentCard.Level;
            set
            {
                int? val = ValidateInt(value, 1, 99);
                CurrentCard.Level = val;
                OnPropertyChanged(nameof(Level));
                UpdateIsValidCard();
            }
        }
        public int? Strength
        {
            get => CurrentCard.Strength;
            set
            {
                int? val = ValidateInt(value, 1, 999);
                CurrentCard.Strength = val;
                OnPropertyChanged(nameof(Strength));
                UpdateIsValidCard();
            }
        }
        public int? Dexterity
        {
            get => CurrentCard.Dexterity;
            set
            {
                int? val = ValidateInt(value, 1, 999);
                CurrentCard.Dexterity = val;
                OnPropertyChanged(nameof(Dexterity));
                UpdateIsValidCard();
            }
        }
        public int? Vitality
        {
            get => CurrentCard.Vitality;
            set
            {
                int? val = ValidateInt(value, 1, 999);
                CurrentCard.Vitality = val;
                OnPropertyChanged(nameof(Vitality));
                UpdateIsValidCard();
            }
        }
        public int? Energy
        {
            get => CurrentCard.Energy;
            set
            {
                int? val = ValidateInt(value, 1, 999);
                CurrentCard.Energy = val;
                OnPropertyChanged(nameof(Energy));
                UpdateIsValidCard();
            }
        }
    }
}
