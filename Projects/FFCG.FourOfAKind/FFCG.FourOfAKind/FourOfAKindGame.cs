using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFCG.FourOfAKind.Game
{
    public class FourOfAKindGame
    {
        public FourOfAKindGame()
        {
            
        }
    }

    public class Suite
    {
        private string _suite;

        public Suite(string suite)
        {
            if (String.Equals(suite,"Spader") || String.Equals(suite,"Hjärter") || String.Equals(suite,"Ruter") || String.Equals(suite,"Klöver"))
            {
                _suite = suite;
            }
            else
            {
                throw new Exception("No such Suite");
            }
        }
        public string GetSuite()
        {
            return _suite;
        }

    }

    public class Card
    {
        private Suite _suite ;
        private int _number;

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (value < 1 || value > 13)
                {
                    throw new OverflowException();
                }

                _number = value;
            }
        }

        public Suite Suite
        {
            get { return _suite; }
        }

        public Card(string suite, int number)
        {
            this.Number = number;
            _suite = new Suite(suite);
        }

        public string PrintCard()
        {
            return _suite.GetSuite() + " " + _number;
        }


    }

    public class Deck
    {
        private static List<Card> _deck;

        public Deck()
        {
            _deck = new List<Card>();
            CreateSuite("Spader");
            CreateSuite("Hjärter");
            CreateSuite("Ruter");
            CreateSuite("Klöver");
        }

        private static void CreateSuite(string suite)
        {
            for (int i = 1; i < 14; i++)
            {
                Card card = new Card(suite, i);
                _deck.Add(card);
            }
        }

        public object PrintSuite(string suite)
        {
            string cardsInDeckWithSuite = "";
            foreach(Card card in _deck)
            {
                Console.WriteLine(card.PrintCard());

                if (string.Equals(card.Suite.GetSuite(),suite))
                {
                    cardsInDeckWithSuite += card.PrintCard()+", ";
                }
            }
            if (cardsInDeckWithSuite.Length>0)
            {
                cardsInDeckWithSuite = cardsInDeckWithSuite.TrimEnd(' ');
                cardsInDeckWithSuite = cardsInDeckWithSuite.TrimEnd(',');

            }
            return cardsInDeckWithSuite;
        }
    }

    public class Hand
    {
        
    }
}
