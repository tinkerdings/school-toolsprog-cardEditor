using CardEditor.Models;
using CardEditor.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class ImportCardCommand : CommandBase
    {
        public EditViewModel EditViewModel { get; set; }
        public ImportCardCommand(EditViewModel editViewModel)
        {
            EditViewModel = editViewModel;
        }

        public override void Execute(object parameter)
        {
            var Dialog = new OpenFileDialog
            {
                Filter = "JSON (*.json)|*.json",
                Title = "Select a Card to Import"
            };

            Dialog.ShowDialog();
            var path = Dialog.FileName;
            if(path != "")
            {
                var json = File.ReadAllText(Dialog.FileName);
                Card? Card = JsonSerializer.Deserialize<Card>(json);

                if(Card != null && Card.Type != null)
                {
                    EditViewModel.ResetCard();
                    EditViewModel.CurrentCard.Name = Card.Name;
                    EditViewModel.CurrentCard.Image = Card.Image;
                    EditViewModel.Database.UpsertCardType(Card.Type.Name, Card.Type);
                    EditViewModel.UpdateCardTypeList();
                    EditViewModel.SelectedCardTypeName = Card.Type.Name;
                    EditViewModel.CurrentCard.Type = Card.Type;
                    EditViewModel.CurrentCard.Level = Card.Level;
                    EditViewModel.CurrentCard.Strength = Card.Strength;
                    EditViewModel.CurrentCard.Dexterity = Card.Dexterity;
                    EditViewModel.CurrentCard.Vitality = Card.Vitality;
                    EditViewModel.CurrentCard.Energy = Card.Energy;
                    EditViewModel.ResetCardStats();
                }
            }
        }
    }
}
