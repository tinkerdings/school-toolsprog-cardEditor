using CardEditor.Commands;
using CardEditor.Models;
using CardEditor.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CardEditor.ViewModels
{
    public class TypeViewModel : ViewModelBase
    {
        public EditViewModel EditViewModel { get; set; }
        public ICommand CloseTypeModalCommand { get; }
        public ICommand RandomizeTypeNameCommand { get; }
        public ICommand RandomizeTypeStatsCommand { get; }
        public ICommand ResetTypeCommand { get; }
        public ICommand SaveTypeCommand { get; }
        public ICommand CreateNewTypeCommand { get; }
        public CardType NewType { get; set; }
        TypeModal TypeModal { get; }
        PropertyValidation PropertyValidation { get; set; }
        public bool IsValidType { get; set; }
        public bool TypeDirty { get; set; }

        public TypeViewModel(TypeModal typeModal, EditViewModel editViewModel) 
        {
            EditViewModel = editViewModel;
            TypeModal = typeModal;
            NewType = new CardType();
            CloseTypeModalCommand = new CloseTypeModalCommand(TypeModal);
            RandomizeTypeNameCommand = new RandomizeTypeNameCommand(this);
            RandomizeTypeStatsCommand = new RandomizeTypeStatsCommand(this);
            CreateNewTypeCommand = new CreateNewTypeCommand(this);
            SaveTypeCommand = new SaveTypeCommand(this);
            ResetTypeCommand = new ResetTypeCommand(this);
            PropertyValidation= new PropertyValidation();
        }
        private void UpdateIsValidType()
        {
            IsValidType = (
                DefaultLevel != null &&
                DefaultStrength != null &&
                DefaultDexterity != null &&
                DefaultVitality != null &&
                DefaultEnergy != null &&
                Name != null);
            OnPropertyChanged(nameof(IsValidType));
        }

        private void UpdateIsTypeDirty()
        {
            TypeDirty = !(
                DefaultLevel == null &&
                DefaultStrength == null &&
                DefaultDexterity == null &&
                DefaultVitality == null &&
                DefaultEnergy == null &&
                Name == null
                );
            OnPropertyChanged(nameof(TypeDirty));
        }

        public string? Name
        {
            get => NewType.Name;
            set
            {
                string? name = PropertyValidation.ValidateString(value, 16);
                NewType.Name = name;
                OnPropertyChanged(nameof(Name));
                UpdateIsValidType();
                UpdateIsTypeDirty();
            }
        }

        public int? DefaultLevel
        {
            get => NewType.DefaultLevel;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 99);
                NewType.DefaultLevel = val;
                OnPropertyChanged(nameof(DefaultLevel));
                UpdateIsValidType();
                UpdateIsTypeDirty();
            }
        }
        public int? DefaultStrength
        {
            get => NewType.DefaultStrength;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 999);
                NewType.DefaultStrength = val;
                OnPropertyChanged(nameof(DefaultStrength));
                UpdateIsValidType();
                UpdateIsTypeDirty();
            }
        }
        public int? DefaultDexterity
        {
            get => NewType.DefaultDexterity;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 999);
                NewType.DefaultDexterity = val;
                OnPropertyChanged(nameof(DefaultDexterity));
                UpdateIsValidType();
                UpdateIsTypeDirty();
            }
        }
        public int? DefaultVitality
        {
            get => NewType.DefaultVitality;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 999);
                NewType.DefaultVitality = val;
                OnPropertyChanged(nameof(DefaultVitality));
                UpdateIsValidType();
                UpdateIsTypeDirty();
            }
        }
        public int? DefaultEnergy
        {
            get => NewType.DefaultEnergy;
            set
            {
                int? val = PropertyValidation.ValidateInt(value, 1, 999);
                NewType.DefaultEnergy = val;
                OnPropertyChanged(nameof(DefaultEnergy));
                UpdateIsValidType();
                UpdateIsTypeDirty();
            }
        }
    }
}
