using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class OpenTypeModalCommand : CommandBase
    {
        public TypeModal TypeModal { get; set; }
        public EditViewModel EditViewModel { get; set; }
        public OpenTypeModalCommand(EditViewModel editViewModel)
        {
            EditViewModel = editViewModel;
        }

        public override void Execute(object parameter)
        {
            TypeModal = new TypeModal(EditViewModel);
            TypeModal.Owner = App.Current.MainWindow;
            TypeModal.ShowDialog();
        }
    }
}
