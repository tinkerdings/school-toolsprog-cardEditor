using CardEditor.Commands;
using CardEditor.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using CardEditor.Database;
using System.Diagnostics;

namespace CardEditor.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        //public TypeModal TypeModal { get; }
        public CardViewModel CurrentCard { get; set; }
        public ICommand CreateNewCardCommand { get; set; }
        public ICommand UploadImageCommand { get; }
        public ICommand OpenTypeModalCommand { get; }
        public ICommand RandomizeStatsCommand { get; }
        public ICommand ExportCardCommand { get; }
        public ICommand ImportCardCommand { get; }
        public ICommand ResetStatsCommand { get; }
        public ICommand ShowCardCommand { get; }
        public ICommand DeleteCardCommand { get; }
        public ICommand RandomizeCardNameCommand { get; }
        public ICommand SaveCardCommand { get; }

        private string _SelectedCardTypeName { get; set; }
        private CardType SelectedCardType { get; set; }
        public string SelectedCardTypeName
        {
            get => _SelectedCardTypeName;
            set
            {
                _SelectedCardTypeName = value;
                SelectedCardType = Database.GetCardType(value);
                CurrentCard.Level = SelectedCardType.DefaultLevel;
                CurrentCard.Strength = SelectedCardType.DefaultStrength;
                CurrentCard.Dexterity = SelectedCardType.DefaultDexterity;
                CurrentCard.Vitality = SelectedCardType.DefaultVitality;
                CurrentCard.Energy = SelectedCardType.DefaultEnergy;
                OnPropertyChanged(nameof(SelectedCardTypeName));
            }
        }
        private List<CardType> _CardTypes { get; set; }
        private List<string> _CardTypeNames { get; set; }
        public List<CardType> CardTypes 
        {
            get => _CardTypes;
            set
            {
                _CardTypes = value;
                OnPropertyChanged(nameof(CardTypes));
            }
        }
        public List<string> CardTypeNames 
        {
            get => _CardTypeNames;
            set
            {
                _CardTypeNames = value;
                OnPropertyChanged(nameof(CardTypeNames));
            }
        }

        public void UpdateCardTypeList()
        {
            var cardTypes = Database.LoadRecords<CardType>("CardTypes");
            CardTypes = cardTypes;
            CardTypeNames = CardTypes.Select(o => o.Name).ToList();
        }

        public void UpdateCard()
        {
            OnPropertyChanged(nameof(CurrentCard));
        }

        public EditViewModel() : base()
        {
            CurrentCard = new CardViewModel();
            UploadImageCommand = new UploadImageCommand(CurrentCard);
            OpenTypeModalCommand = new OpenTypeModalCommand(this);
            RandomizeStatsCommand = new RandomizeStatsCommand(CurrentCard);
            ExportCardCommand = new ExportCardCommand();
            ImportCardCommand = new ImportCardCommand();
            ResetStatsCommand = new ResetStatsCommand(CurrentCard);
            ShowCardCommand = new ShowCardCommand();
            SaveCardCommand = new SaveCardCommand();
            DeleteCardCommand = new DeleteCardCommand();
            RandomizeCardNameCommand = new RandomizeCardNameCommand(CurrentCard);
            CreateNewCardCommand = new CreateNewCardCommand(this);

            UpdateCardTypeList();
        }
    }
}
