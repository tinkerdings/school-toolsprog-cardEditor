using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class CloseDisplayCardModalCommand : CommandBase
    {
        public EditViewModel EditViewModel { get; set; }
        public CloseDisplayCardModalCommand(EditViewModel editViewModel) 
        {
            EditViewModel = editViewModel;
        }
        public override void Execute(object parameter)
        {
            EditViewModel.DisplayCardModal.Close();
        }
    }
}
