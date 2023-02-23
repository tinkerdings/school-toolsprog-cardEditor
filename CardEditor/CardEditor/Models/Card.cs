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
        public string? TypeName { get; set; }
        public int? DefaultLevel {get; set;}
        public int? DefaultStrength {get; set;}
        public int? DefaultDexterity {get; set;}
        public int? DefaultVitality {get; set;}
        public int? DefaultEnergy {get; set;}
        public CardType(
            string? name = null,
            int? level = null,
            int? strength = null,
            int? dexterity = null,
            int? vitality = null,
            int? energy = null)
        {
            TypeName = name;
            DefaultLevel = level;
            DefaultStrength = strength;
            DefaultDexterity = dexterity;
            DefaultVitality = vitality;
            DefaultEnergy = energy;
        }
    }

    public class Card
    {
        public string? Name { get; set; }
        public CardType? Type { get; set; }
        public int? Level { get; set; }
        public int? Strength { get; set; }
        public int? Dexterity { get; set; }
        public int? Vitality { get; set; }
        public int? Energy { get; set; }
        public string? Image { get; set; }

        public Card(
            string? name = null,
            CardType? cardType = null,
            int? level = null,
            int? strength = null,
            int? dexterity = null,
            int? vitality = null,
            int? energy = null,
            string? image = null)
        {
            Name = null;
            Type = new CardType();
            Level = level;
            Strength = strength;
            Dexterity = dexterity;
            Vitality = vitality;
            Energy = energy;
            Image = image;
        }
    }
}
