using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class DeleteCardCommand : CommandBase
    {
        EditViewModel EditViewModel { get; set; }
        ViewModelLocator ViewModelLocator { get; set; }
        public DeleteCardCommand(EditViewModel editViewModel) 
        {
            EditViewModel = editViewModel;
        }
        public override void Execute(object parameter)
        {
            EditViewModel.Database.DeleteCard(EditViewModel.CurrentCard.Name);
            ViewModelLocator = new ViewModelLocator();
            ViewModelLocator.BrowseViewModel.Update();
            EditViewModel.ResetCard();
        }
    }
}
