using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class RandomizeStatsCommand : CommandBase
    {
        public CardViewModel CardViewModel { get; set; }
        public RandomizeStatsCommand(CardViewModel cardViewModel)
        {
            CardViewModel = cardViewModel;
        }
        public override void Execute(object parameter)
        {
            Random r = new Random();
            CardViewModel.Level = r.Next(1, 100);
            CardViewModel.Strength = r.Next(1, 1000);
            CardViewModel.Dexterity = r.Next(1, 1000);
            CardViewModel.Vitality = r.Next(1, 1000);
            CardViewModel.Energy = r.Next(1, 1000);
        }
    }
}
