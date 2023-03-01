using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CardEditor.Models
{
    public class CardType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Name { get; set; }
        public int? DefaultLevel {get; set;}
        public int? DefaultStrength {get; set;}
        public int? DefaultDexterity {get; set;}
        public int? DefaultVitality {get; set;}
        public int? DefaultEnergy {get; set;}
        public CardType()
        {
            Name = null;
            DefaultLevel = null;
            DefaultStrength = null;
            DefaultDexterity = null;
            DefaultVitality = null;
            DefaultEnergy = null;
        }
    }

    public class Card
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;}
        public string? Name { get; set; }
        public CardType? Type { get; set; }
        public int? Level { get; set; }
        public int? Strength { get; set; }
        public int? Dexterity { get; set; }
        public int? Vitality { get; set; }
        public int? Energy { get; set; }
        public string? Image { get; set; }

        public Card()
        {
            Name = null;
            Type = null;
            Level = null;
            Strength = null;
            Dexterity = null;
            Vitality = null;
            Energy = null;
            Image = null;
        }
    }
}
