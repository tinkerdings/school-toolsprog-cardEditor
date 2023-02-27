using CardEditor.Models;
using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    class CreateNewCardCommand : CommandBase
    {
        public EditViewModel EditViewModel { get; set; }

        public CreateNewCardCommand(EditViewModel editViewModel)
        {
            EditViewModel = editViewModel;
        }

        public override void Execute(object parameter)
        {
            EditViewModel.CurrentCard.Name = null;
            EditViewModel.CurrentCard.Type = null;
            EditViewModel.CurrentCard.Image = null;
            EditViewModel.ResetStatsCommand.Execute(null);
        }
    }
}
