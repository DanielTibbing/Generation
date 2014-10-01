using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FFCG.Calc.Kata
{
    public class StringCalculator
    {
        private const int DefaultValue = 0;
        private const char DefaultDelimiter = ',';

        internal object Add(string numbers)
        {
            if (StringIsEmpty(numbers))
            {
                return DefaultValue;   
            }
            /*if (numbers.Length.Equals(1))
            {
                return Int32.Parse(numbers);
            }*/
            if (StringHasModifiedDelimiter(numbers))
            {
                numbers = ReplaceModifiedDelimiterWithDefaultDelimiter(numbers);
            }
            numbers = numbers.Replace('\n', DefaultDelimiter);
             return AddNumbers(numbers);
        }

        private static string ReplaceModifiedDelimiterWithDefaultDelimiter(string numbers)
        {
            numbers = numbers.Substring(4).Replace(numbers[2], DefaultDelimiter);
            return numbers;
        }

        private static bool StringHasModifiedDelimiter(string numbers)
        {
            if (numbers.Length>1)
            {
                return numbers.Substring(0, 2).Equals("//");
            }
            return false;

        }

        private static bool StringIsEmpty(string numbers)
        {
            return numbers.Equals("");
        }

        internal int AddNumbers(string numbers)
        {
            int result = DefaultValue;
            string[] allNumbers = numbers.Split(DefaultDelimiter);
            foreach (string number in allNumbers)
            {
                result += Int32.Parse(number);
            }
            return result;
        }
    }

    [TestFixture]
    public class StringCalculatorTest
    {
        [Test]
        public void Add_WithEmptyString_Returns0()
        {
            ArrangeActAssert("",0);
        }

        [TestCase("11", 11)]
        [TestCase("0", 0)]
        public void Add_WithOneNumberInString_ReturnsNumber(string numbers, int expected)
        {
            ArrangeActAssert(numbers,expected);
        }

        [TestCase("1,2", 3)]
        [TestCase("1,0", 1)]
        public void Add_WithTwoNumbersInString_ReturnsNumberAddedTogether(string numbers, int expected)
        {
            ArrangeActAssert(numbers, expected);
        }

        [TestCase("1,2,23,5", 31)]
        [TestCase("1,2,3", 6)]
        public void Add_WithUnkownNumbersInString_ReturnsNumberAddedTogether(string numbers, int expected)
        {
            ArrangeActAssert(numbers, expected);
        }

        [TestCase("1\n2\n3,4", 10)]
        [TestCase("1,2\n3", 6)]
        public void Add_WithUnkownNumbersInStringAndAllowsNewLine_ReturnsNumberAddedTogether(string numbers, int expected)
        {
            ArrangeActAssert(numbers, expected);
        }

        [TestCase("//+\n1+2+3", 6)]
        [TestCase("//-\n1-2-3", 6)]
        [TestCase("//.\n1.2.3", 6)]
        [TestCase("//_\n1_2_3", 6)]
        public void Add_WithUnkownNumbersInStringAndAllowsAnyDelimiter_ReturnsNumberAddedTogether(string numbers,int expected)
        {
            ArrangeActAssert(numbers, expected);
        }

        private static void ArrangeActAssert(string numbers, int expected)
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(numbers);
            Assert.AreEqual(expected,result);
        }

    }
}
