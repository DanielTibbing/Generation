using System;
using System.Collections.Generic;

namespace FFCG.FourOfAKind.Game
{
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

        public void RemoveCard(string suite, int number)
        {
            _deck.RemoveAll(card => (card.Suite.GetSuite().Equals(suite) && card.Number == number));
        }
    }
}