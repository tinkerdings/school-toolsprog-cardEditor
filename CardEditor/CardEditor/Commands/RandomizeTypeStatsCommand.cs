using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class RandomizeTypeStatsCommand : CommandBase
    {
        public TypeViewModel TypeViewModel { get; set; }
        public RandomizeTypeStatsCommand(TypeViewModel typeViewModel) 
        { 
            TypeViewModel = typeViewModel;
        }
        public override void Execute(object parameter)
        {
            Random r = new Random();
            TypeViewModel.DefaultLevel = r.Next(1, 100);
            TypeViewModel.DefaultStrength = r.Next(1, 1000);
            TypeViewModel.DefaultDexterity = r.Next(1, 1000);
            TypeViewModel.DefaultVitality = r.Next(1, 1000);
            TypeViewModel.DefaultEnergy = r.Next(1, 1000);
        }
    }
}
