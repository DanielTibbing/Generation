using System;

namespace FFCG.FourOfAKind.Game
{
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
}