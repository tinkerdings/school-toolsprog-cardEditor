using CardEditor.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CardEditor.ViewModels
{
    public class TypeViewModel : ViewModelBase
    {
        public ICommand CloseTypeModalCommand { get; }
        TypeModal TypeModal { get; }

        public TypeViewModel(TypeModal typeModal) 
        {
            TypeModal = typeModal;
            CloseTypeModalCommand = new CloseTypeModalCommand(TypeModal);
        }
    }
}
