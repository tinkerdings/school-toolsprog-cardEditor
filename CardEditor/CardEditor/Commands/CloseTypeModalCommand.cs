using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class CloseTypeModalCommand : CommandBase
    {
        TypeModal TypeModal { get; }
        public CloseTypeModalCommand(TypeModal typeModal)
        {
            TypeModal = typeModal;
        }

        public override void Execute(object parameter)
        {
            TypeModal.Close();
        }
    }
}
