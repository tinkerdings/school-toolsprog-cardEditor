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
using MongoDB.Bson.Serialization.Serializers;

namespace CardEditor.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        //public TypeModal TypeModal { get; }
        public ViewModelLocator ViewModelLocator { get; set; }
        public CardViewModel CurrentCard { get; set; }
        public ICommand CreateNewCardCommand { get; set; }
        public ICommand UploadImageCommand { get; }
        public ICommand OpenTypeModalCommand { get; }
        public ICommand RandomizeStatsCommand { get; }
        public ICommand ExportCardCommand { get; }
        public ICommand ImportCardCommand { get; }
        public ICommand ResetStatsCommand { get; }
        public ICommand ShowCardCommand { get; }
        public ICommand CloseDisplayCardModalCommand { get; }
        public ICommand DeleteCardCommand { get; }
        public ICommand RandomizeCardNameCommand { get; }
        public ICommand SaveCardCommand { get; }
        public DisplayCardModal DisplayCardModal { get; set; }

        private string? _SelectedCardTypeName { get; set; }
        private CardType? SelectedCardType { get; set; }
        public string? SelectedCardTypeName
        {
            get => _SelectedCardTypeName;
            set
            {
                _SelectedCardTypeName = value;
                SelectedCardType = Database.GetCardType(value);
                CurrentCard.Type = SelectedCardType;
                OnPropertyChanged(nameof(SelectedCardTypeName));
            }
        }
        private List<CardType> _CardTypes { get; set; }
        private List<string?> _CardTypeNames { get; set; }
        public List<CardType> CardTypes 
        {
            get => _CardTypes;
            set
            {
                _CardTypes = value;
                OnPropertyChanged(nameof(CardTypes));
            }
        }
        public List<string?> CardTypeNames 
        {
            get => _CardTypeNames;
            set
            {
                _CardTypeNames = value;
                OnPropertyChanged(nameof(CardTypeNames));
            }
        }

        public void SetCard(Card card)
        {
            ResetCard();
            SelectedCardTypeName = card.Type.Name;
            SelectedCardType = card.Type;
            CurrentCard.Name = card.Name;
            CurrentCard.Level = card.Level;
            CurrentCard.Image = card.Image;
            CurrentCard.Strength = card.Strength;
            CurrentCard.Dexterity = card.Dexterity;
            CurrentCard.Vitality = card.Vitality;
            CurrentCard.Energy = card.Energy;
        }

        public void UpdateCardTypeList()
        {
            var cardTypes = Database.LoadRecords<CardType>();
            CardTypes = cardTypes;
            CardTypeNames = CardTypes.Select(o => o.Name).ToList();
            SelectedCardTypeName = SelectedCardTypeName;
            //OnPropertyChanged(nameof(SelectedCardType));
        }

        public void ResetCard()
        {
            CurrentCard.ResetCard();
            SelectedCardTypeName = null;
            OnPropertyChanged(nameof(CurrentCard));
        }

        public void ResetCardStats()
        {
            ResetStatsCommand.Execute(null);
        }

        public void UpdateCard()
        {
            OnPropertyChanged(nameof(CurrentCard));
        }

        public EditViewModel() : base()
        {
            CurrentCard = new CardViewModel();
            ResetCard();
            ViewModelLocator = new ViewModelLocator();
            UploadImageCommand = new UploadImageCommand(CurrentCard);
            OpenTypeModalCommand = new OpenTypeModalCommand(this);
            RandomizeStatsCommand = new RandomizeStatsCommand(CurrentCard);
            ExportCardCommand = new ExportCardCommand(this);
            ImportCardCommand = new ImportCardCommand(this);
            ResetStatsCommand = new ResetStatsCommand(this);
            ShowCardCommand = new ShowCardCommand(this);
            CloseDisplayCardModalCommand = new CloseDisplayCardModalCommand(this);
            DisplayCardModal = null;
            SaveCardCommand = new SaveCardCommand(this);
            DeleteCardCommand = new DeleteCardCommand(this);
            RandomizeCardNameCommand = new RandomizeCardNameCommand(CurrentCard);
            CreateNewCardCommand = new CreateNewCardCommand(this);

            UpdateCardTypeList();
        }
    }
}
