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

namespace CardEditor.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        //public TypeModal TypeModal { get; }
        public CardViewModel CurrentCard { get; }
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

        public CardType[] CardTypes { get; }

        public EditViewModel()
        {
            CurrentCard = new CardViewModel();
            UploadImageCommand = new UploadImageCommand(CurrentCard);
            OpenTypeModalCommand = new OpenTypeModalCommand();
            RandomizeStatsCommand = new RandomizeStatsCommand();
            ExportCardCommand = new ExportCardCommand();
            ImportCardCommand = new ImportCardCommand();
            ResetStatsCommand = new ResetStatsCommand();
            ShowCardCommand = new ShowCardCommand();
            SaveCardCommand = new SaveCardCommand();
            DeleteCardCommand = new DeleteCardCommand();
            RandomizeCardNameCommand = new RandomizeCardNameCommand();
        }
    }
}
