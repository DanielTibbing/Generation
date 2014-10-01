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
            if (numbers.Length.Equals(1))
            {
                return Int32.Parse(numbers);
            }
            if (StringHasModifiedDelimiter(numbers))
            {
                numbers = numbers.Substring(4).Replace(numbers[2], DefaultDelimiter);
            }
            numbers = numbers.Replace('\n', DefaultDelimiter);
             return AddNumbers(numbers);
        }

        private static bool StringHasModifiedDelimiter(string numbers)
        {
            return numbers.Substring(0, 2).Equals("//");
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

        [Test]
        public void Add_WithOneNumberInString_ReturnsNumber()
        {
            ArrangeActAssert("1", 1);
        }

        [Test]
        public void Add_WithTwoNumbersInString_ReturnsNumberAddedTogether()
        {
            ArrangeActAssert("1,2", 3);
        }

        [Test]
        public void Add_WithUnkownNumbersInString_ReturnsNumberAddedTogether()
        {
            ArrangeActAssert("1,2,3", 6);
        }

        [Test]
        public void Add_WithUnkownNumbersInStringAndAllowsNewLine_ReturnsNumberAddedTogether()
        {
            ArrangeActAssert("1,2\n3", 6);
        }

        [Test]
        public void Add_WithUnkownNumbersInStringAndAllowsAnyDelimiter_ReturnsNumberAddedTogether()
        {
            ArrangeActAssert("//+\n1+2+3", 6);
        }
        private static void ArrangeActAssert(string numbers, int expected)
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(numbers);
            Assert.AreEqual(expected,result);
        }

    }
}
