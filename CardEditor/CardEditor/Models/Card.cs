using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Models
{
    public class CardType
    {
        public string TypeName { get; set; }
        public int DefaultLevel {get; set;}
        public int DefaultStrength {get; set;}
        public int DefaultDexterity {get; set;}
        public int DefaultVitality {get; set;}
        public int DefaultEnergy {get; set;}
        public CardType(string name, int level, int strength, int dexterity, int vitality, int energy)
        {
            TypeName = name;
            DefaultLevel = level;
            DefaultStrength = strength;
            DefaultDexterity= dexterity;
            DefaultVitality= vitality;
            DefaultEnergy= energy;
        }
    }

    public class Card
    {
        string name;
        CardType type;
        int level;
        int strength;
        int dexterity;
        int vitality;
        int energy;
    }
}
