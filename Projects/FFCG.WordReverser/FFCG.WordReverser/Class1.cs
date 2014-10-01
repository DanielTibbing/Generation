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
        internal object ReverseWord(string text)
        {
            string[] textArray = text.Split(' ');
            if (textArray.Length==1)
            {
                return text;

            }
            else
            {
                return textArray[1] + ' ' + textArray[0];
            }
        }
    }

    [TestFixture]
    public class WordReverserTest
    {
        [TestCase("hello", "hello")]
        [TestCase("", "")]
        public void ReverseWordOrder_WithOneWord_ReturnsTheWord(string text, string expected)
        {
            ArrangeActAssert(text,expected);
        }

        [TestCase("hello world", "world hello")]
        public void ReverseWordOrder_WithTwoWords_ReturnsTheWordsInReversedOrder(string text, string expected)
        {
            ArrangeActAssert(text, expected);
        }

        private static void ArrangeActAssert(string text, string expected)
        {
            var wordReverser = new WordReverser();

            var result = wordReverser.ReverseWord(text);
            Assert.AreEqual(expected, result);
        }

    }
}
