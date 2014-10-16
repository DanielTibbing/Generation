using System;
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
        private static string _suite;

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

       /* public Card createCard(string suite, int number)
        {
            //this.Number = number;
            //_suite = new Suite(suite);
        }*/


    }

    public class Deck
    {
        
    }

    public class Hand
    {
        
    }
}
