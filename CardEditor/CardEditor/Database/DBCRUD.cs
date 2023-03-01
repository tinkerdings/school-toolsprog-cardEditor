using CardEditor.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEditor.Database
{
    public class DBCRUD
    {
        private IMongoDatabase db;
        public IMongoCollection<Card> Cards => GetCollection<Card>();
        public IMongoCollection<CardType> CardTypes => GetCollection<CardType>();

        private static ObservableCollection<Card> _cards { get; set; }

        public ObservableCollection<Card> ObservableCards
        {
            get
            {
                _cards = new ObservableCollection<Card>();
                var allCards = LoadRecords<Card>();
                Debug.WriteLine(allCards.Count);
                for(int i = allCards.Count-1; i >= 0; i--)
                {
                    _cards.Add(allCards[i]);
                }

                return _cards;
            }
        }

        private readonly Dictionary<Type, string> _Collections = new()
        {
            {typeof(Card), "Cards" },
            {typeof(CardType), "CardTypes"}
        };

        private IMongoCollection<T> GetCollection<T>()
        {
            return db.GetCollection<T>(_Collections[typeof(T)]);
        }

        public DBCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public List<T> LoadRecords<T>()
        {
            var collection = GetCollection<T>();

            return collection.Find(new BsonDocument()).ToList();
        }

        public bool CardExists(string cardName)
        {
            return ((Cards.Find(c => c.Name == cardName).FirstOrDefault()) != null);
        }
        public bool CardTypeExists(string typeName)
        {
            return ((CardTypes.Find(t => t.Name == typeName).FirstOrDefault()) != null);
        }
        public bool Exists<T>(string name)
        {
            if(typeof(T) == typeof(Card))
            {
                return CardExists(name);
            }
            if(typeof(T) == typeof(CardType))
            {
                return CardTypeExists(name);
            }

            return false;
        }

        public Card GetCard(string cardName)
        {
            return Cards.Find(c => c.Name == cardName).FirstOrDefault();
        }
        public CardType GetCardType(string typeName)
        {
            return CardTypes.Find(t => t.Name == typeName).FirstOrDefault();
        }

        public void UpsertCardType(string typeName, CardType cardType)
        {
            var collection = GetCollection<CardType>();
            if(Exists<CardType>(typeName))
            {
                CardType t = GetCardType(typeName);
                var id = t.Id;
                DeleteCardType(typeName);
                InsertRecord<CardType>(cardType);
            }
            else
            {
                InsertRecord<CardType>(cardType);
            }
        }
        public void UpsertCard(Card card)
        {
            var collection = GetCollection<Card>();
            if(Exists<Card>(card.Name))
            {
                Card c = GetCard(card.Name);
                var id = c.Id;
                DeleteCard(card.Name);
            }
            InsertRecord<Card>(card);
        }
        public void InsertRecord<T>(T record)
        {
            var collection = GetCollection<T>();
            collection.InsertOne(record);
        }
        public void DeleteCardType(string name)
        {
            var collection = GetCollection<CardType>();
            collection.DeleteOneAsync(t => t.Name == name);
        }
        public void DeleteCard(string name)
        {
            var collection = GetCollection<Card>();
            collection.DeleteOneAsync(c => c.Name == name);
        }
    }
}
