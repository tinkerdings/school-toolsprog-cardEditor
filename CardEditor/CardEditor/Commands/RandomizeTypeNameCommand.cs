using CardEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Commands
{
    public class RandomizeTypeNameCommand : CommandBase
    {
        TypeViewModel TypeViewModel { get; set; }
        public RandomizeTypeNameCommand(TypeViewModel typeViewModel) 
        {
            TypeViewModel = typeViewModel;
        }
        private string[] TypeNames =
        {
            "WIZARD", "SORCERESS", "PALADIN", "AMAZON", "ROGUE",
            "PYROMANCER", "NECROMANCER", "HIGHELF", "DARKELF",
            "BEHEMOTH", "BEAST", "UNDEAD", "ASSASSIN", "ORACLE",
            "OVERSEER", "THIEF", "WRAITH", "SPIRIT", "DEMON",
            "AQUAMANCER", "BARBARIAN", "ABOMINATION", "ILLUSION",
            "DEITY", "GOD", "DEMIGOD", "PEASANT", "TROUBADOUR",
            "GUARD", "CRIMINAL", "DANCER", "HYBRID", "FLESHPILE",
            "IMPOSSIBILITY", "LEGEND", "OUTCAST", "HALLUCINATION",
            "ASTRAL", "ELEMENTAL", "BOGCREATURE", "TROLL", "DWARF",
            "REPTILIAN", "POLITICIAN", "JOKER"
        };
        public override void Execute(object parameter)
        {
            Random r = new Random();
            int index = r.Next(0, TypeNames.Length);
            TypeViewModel.Name = TypeNames[index];
        }
    }
}
