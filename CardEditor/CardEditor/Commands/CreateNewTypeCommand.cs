using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    internal class CreateNewTypeCommand : CommandBase
    {
        public TypeViewModel TypeViewModel;
        public CreateNewTypeCommand(TypeViewModel typeViewModel)
        {
            TypeViewModel = typeViewModel;
        }
        public override void Execute(object parameter)
        {
            TypeViewModel.NewType = new Models.CardType();
            TypeViewModel.Name = null;
            TypeViewModel.DefaultLevel = null;
            TypeViewModel.DefaultStrength = null;
            TypeViewModel.DefaultDexterity = null;
            TypeViewModel.DefaultVitality = null;
            TypeViewModel.DefaultEnergy = null;
        }
    }
}
