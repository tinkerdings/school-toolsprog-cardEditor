using CardEditor.Database;
using CardEditor.Models;
using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class OpenTypeModalCommand : CommandBase
    {
        public TypeModal TypeModal { get; set; }
        public EditViewModel EditViewModel { get; set; }
        public TypeViewModel TypeViewModel { get;set; }
        public OpenTypeModalCommand(EditViewModel editViewModel)
        {
            EditViewModel = editViewModel;
        }

        public override void Execute(object parameter)
        {
            TypeModal = new TypeModal(EditViewModel);
            TypeViewModel = TypeModal.TypeViewModel;
            if (EditViewModel.SelectedCardTypeName != null)
            {
                CardType currentType = TypeViewModel.Database.GetCardType(EditViewModel.SelectedCardTypeName);
                TypeViewModel.Name = currentType.Name;
                TypeViewModel.DefaultLevel = currentType.DefaultLevel;
                TypeViewModel.DefaultStrength = currentType.DefaultStrength;
                TypeViewModel.DefaultDexterity = currentType.DefaultDexterity;
                TypeViewModel.DefaultVitality = currentType.DefaultVitality;
                TypeViewModel.DefaultEnergy = currentType.DefaultEnergy;
            }
            TypeModal.Owner = App.Current.MainWindow;
            TypeModal.ShowDialog();
        }
    }
}
