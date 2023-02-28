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
                TypeViewModel.Name = EditViewModel.CurrentCard.Type.Name;
                TypeViewModel.DefaultLevel = EditViewModel.CurrentCard.Level;
                TypeViewModel.DefaultStrength = EditViewModel.CurrentCard.Strength;
                TypeViewModel.DefaultDexterity = EditViewModel.CurrentCard.Dexterity;
                TypeViewModel.DefaultVitality = EditViewModel.CurrentCard.Vitality;
                TypeViewModel.DefaultEnergy = EditViewModel.CurrentCard.Energy;
            }
            TypeModal.Owner = App.Current.MainWindow;
            TypeModal.ShowDialog();
        }
    }
}
