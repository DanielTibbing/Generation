using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFCG.FourOfAKind.Game;
using NUnit.Framework;

namespace FFCG.FourOfAKind.Tests
{
    [TestFixture]
    public class FourOfAKindTest
    {
       // [TestCase("hello", "hello")]
       // [TestCase("", "")]
        [TestCase]
        public void CreateSuite_ReturnsValidSuite()
        {
            //ArrangeActAssert(text, expected);
            Suite result = new Suite("Klöver");

            Assert.AreEqual("Klöver", result.GetSuite());
            result = new Suite("Spader");

            Assert.AreEqual("Spader", result.GetSuite());
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

        [TestCase("hello glorious world!", "world glorious hello!")]
        [TestCase("Hej min kära mor. Ät banan, äpple och päron!", "päron och äpple banan. Ät mor, kära min Hej!")]
        public void ReverseWordOrder_WithUnkownAmountOfWordsAndDelimitors_ReturnsTheWordsInReversedOrderAndDelimitorsInOriginalPosition(string text,
            string expected)
        {
            ArrangeActAssert(text, expected);
        }

        private static void ArrangeActAssert(string text, string expected)
        {
            var fourofakind = new FourOfAKindGame();

            //object result = wordReverser.FourOfAKind();
            //Assert.AreEqual(expected, result);
        }
    }
}
