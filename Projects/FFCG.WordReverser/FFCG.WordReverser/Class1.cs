using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            } Debug.Print(textArray.ToString());
            string reversedtext = "";
            string[] reversedStringArray = textArray.Reverse().ToArray();

            for (int i = 0; i<textArray.Length;i++)
            {
                reversedtext += reversedStringArray[i]+" ";
            }
            return reversedtext.Substring(0,reversedtext.Length-1);
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

        [TestCase("hello glorious world", "world glorious hello")]
        public void ReverseWordOrder_WithUnkownAmountOfWords_ReturnsTheWordsInReversedOrder(string text, string expected)
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
