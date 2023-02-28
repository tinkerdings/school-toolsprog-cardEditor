using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class SaveCardCommand : CommandBase
    {
        public EditViewModel EditViewModel { get; set; }
        public SaveCardCommand(EditViewModel editViewModel)
        {
            EditViewModel = editViewModel;
        }

        public override void Execute(object parameter)
        {
            EditViewModel.Database.UpsertCard(EditViewModel.CurrentCard.Name, EditViewModel.CurrentCard.CardData);
            EditViewModel.ResetCard();
        }
    }
}
