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

        public override void Execute(object parameter)
        {
            TypeModal = new TypeModal();
            TypeModal.Owner = App.Current.MainWindow;
            TypeModal.ShowDialog();
        }
    }
}
