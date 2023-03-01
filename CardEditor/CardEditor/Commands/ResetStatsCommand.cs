using CardEditor.Models;
using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class ResetStatsCommand : CommandBase
    {
        public EditViewModel EditViewModel { get; set; } 
        public ResetStatsCommand(EditViewModel editViewModel)
        {
            EditViewModel = editViewModel;
        }
        public override void Execute(object parameter)
        {
            CardType currentType = EditViewModel.Database.GetCardType(EditViewModel.SelectedCardTypeName);
            if(currentType != null)
            {
                EditViewModel.CurrentCard.Level = currentType.DefaultLevel;
                EditViewModel.CurrentCard.Strength = currentType.DefaultStrength;
                EditViewModel.CurrentCard.Dexterity = currentType.DefaultDexterity;
                EditViewModel.CurrentCard.Vitality = currentType.DefaultVitality;
                EditViewModel.CurrentCard.Energy = currentType.DefaultEnergy;
            }
        }
    }
}
