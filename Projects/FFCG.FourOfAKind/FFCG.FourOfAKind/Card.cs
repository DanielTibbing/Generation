using System;

namespace FFCG.FourOfAKind.Game
{
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
}