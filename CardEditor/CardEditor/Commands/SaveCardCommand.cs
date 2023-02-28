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
            EditViewModel.Database.UpsertCard(EditViewModel.CurrentCard.CardData);
            var ViewModelLocator = EditViewModel.ViewModelLocator;
            var BrowseViewModel = ViewModelLocator.BrowseViewModel;
            BrowseViewModel.Update();
            EditViewModel.ResetCard();
        }
    }
}
