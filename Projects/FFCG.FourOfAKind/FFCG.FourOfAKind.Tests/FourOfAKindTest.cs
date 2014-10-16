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
            var result = new Suite("Klöver");

            Assert.AreEqual("Klöver", result.GetSuite());
            result = new Suite("Spader");

            Assert.AreEqual("Spader", result.GetSuite());
        }

        [TestCase]
        public void CreateCardWithNumberAndSuite_ReturnsStringRepresentationOfThatCard()
        {
            //ArrangeActAssert(text, expected);
            var result = new Card("Klöver",13);

            Assert.AreEqual("Klöver 13", result.PrintCard());

            result = new Card("Spader",1);

            Assert.AreEqual("Spader 1", result.PrintCard());
            Assert.AreEqual("Spader 1", result.Suite.GetSuite() + " " + result.Number);

        }

        [TestCase]
        public void CreateDeckWith13CardsOfSameSuite_ReturnsStringRepresentationOfThoseCards()
        {
            string expectedResult =
                "Spader 1, Spader 2, Spader 3, Spader 4, Spader 5, Spader 6, Spader 7, Spader 8, Spader 9, Spader 10, Spader 11, Spader 12, Spader 13";
            //ArrangeActAssert(text, expected);
            var result = new Deck();

            Assert.AreEqual(expectedResult, result.PrintSuite("Spader"));

          //  result = new Card("Spader", 1);

           // Assert.AreEqual("Spader 1", result.PrintCard());
        }

        [TestCase]
        public void RemoveCardFromDeckWith13CardsOfSameSuite_ReturnsStringRepresentationOfThoseCards()
        {
            string expectedResult =
                "Spader 1, Spader 2, Spader 3, Spader 4, Spader 5, Spader 6, Spader 7, Spader 8, Spader 9, Spader 11, Spader 12, Spader 13";
            //ArrangeActAssert(text, expected);
            var result = new Deck();

            result.RemoveCard("Spader", 10);

            Assert.AreEqual(expectedResult, result.PrintSuite("Spader"));

            //  result = new Card("Spader", 1);

            // Assert.AreEqual("Spader 1", result.PrintCard());
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
