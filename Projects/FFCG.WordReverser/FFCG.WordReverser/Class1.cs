using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FFCG.WordReverser
{
    public class WordReverser
    {
        public object ReverseWord(string text)
        {
            return text;
        }
    }

    [TestFixture]
    public class WordReverserTest
    {
        [TestCase("hello", "hello")]
        public void ReverseWordOrder_WithOneWord_ReturnsTheWord(string text, string expected)
        {
            ArrangeActAssert(text,expected);
        }

        private static void ArrangeActAssert(string text, string expected)
        {
            var wordReverser = new WordReverser();

            var result = wordReverser.ReverseWord(text);
            Assert.AreEqual(expected, result);
        }

    }
}
