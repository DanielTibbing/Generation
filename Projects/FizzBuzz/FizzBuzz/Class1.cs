using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FizzBuzz
{
    public class FizzBuzz : IFizzBuzzKata
    {
        public string Answer(int number)
        {
            string answer = "";
            if (number%3==0)
                answer += "fizz";
            if (number%5 == 0)
                answer += "buzz";
            if ((number%3 != 0 && number%5 != 0))
                answer = number.ToString();
            return answer;
        }
 
    }

    public interface IFizzBuzzKata
    {
        /// <summary>
        /// Give an answer to the current game
        /// </summary>
        /// <param name="number">current number in the game sequence</param>
        /// <returns>appropriate answer to the current number</returns>
        string Answer(int number);
    }

    [TestFixture]
    public class FizzBuzzTest
    {
        [TestCase(0, "fizzbuzz")]
        public void FizzBuzz_WithNumber0_ReturnsFizzBuzz(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }
        [TestCase(1, "1")]
        public void FizzBuzz_WithNumber1_Returns1(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }
        [TestCase(3, "fizz")]
        public void FizzBuzz_WithNumber3_ReturnsFizz(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }
        [TestCase(5, "buzz")]
        public void FizzBuzz_WithNumber5_ReturnsBuzz(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }

        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(4, "4")]
        [TestCase(7, "7")]
        [TestCase(8, "8")]
        [TestCase(11, "11")]
        [TestCase(13, "13")]
        [TestCase(14, "14")]
        public void FizzBuzz_WithNumberNotDividableBy3or5_ReturnsNumber(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }

        [TestCase(3, "fizz")]
        [TestCase(6, "fizz")]
        [TestCase(9, "fizz")]
        [TestCase(12, "fizz")]
        public void FizzBuzz_WithNumbeDividableBy3ButNot5_ReturnsFizz(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }

        [TestCase(5, "buzz")]
        [TestCase(10, "buzz")]
        public void FizzBuzz_WithNumbeDividableBy5ButNot3_ReturnsBuzz(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }

        [TestCase(0, "fizzbuzz")]
        [TestCase(15, "fizzbuzz")]
        public void FizzBuzz_WithNumbeDividableBy3And5_ReturnsFizzBuzz(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }

        private static void ArrangeActAssert(int number, string expected)
        {
            var fizzBuzz = new FizzBuzz();

            string result = fizzBuzz.Answer(number);
            Assert.AreEqual(expected, result);
        }
    }
}
