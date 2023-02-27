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
        public CardViewModel CardViewModel { get; set; } 
        public ResetStatsCommand(CardViewModel cardViewModel)
        {
            CardViewModel = cardViewModel;
        }
        public override void Execute(object parameter)
        {
            CardViewModel.Level = null;
            CardViewModel.Strength = null;
            CardViewModel.Dexterity = null;
            CardViewModel.Vitality = null;
            CardViewModel.Energy = null;
        }
    }
}
