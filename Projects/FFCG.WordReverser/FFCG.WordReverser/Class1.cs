﻿using System;
using System.Collections;
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
            if (TextOnlyContainsOneWord(textArray))
            {
                return text;

            }
            return ReverseTextFromArray(textArray);
        }

        private static bool TextOnlyContainsOneWord(string[] textArray)
        {
            return textArray.Length==1;
        }

        private static object ReverseTextFromArray(string[] textArray)
        {
            var reversedStringArray = ReverseTextArray(textArray);
            var delimitersAndPositions = RemoveDelimitersAndKeepTheirPositions(textArray, reversedStringArray);
            AddTheDelimitersAgain(delimitersAndPositions, reversedStringArray);
            return CreateReversedStringFromTextArrayWithSpaceBetweenWords(reversedStringArray);
        }

        private static string CreateReversedStringFromTextArrayWithSpaceBetweenWords(string[] reversedStringArray)
        {
            string reversedtext = "";
            for (int i = 0; i < reversedStringArray.Length; i++)
            {
                reversedtext = AddWordToTextWithSpaceIfNeeded(reversedStringArray, i, reversedtext);
            }
            return reversedtext;
        }

        private static string AddWordToTextWithSpaceIfNeeded(string[] reversedStringArray, int i, string reversedtext)
        {
            if (i != reversedStringArray.Length - 1)
            {
                reversedtext += reversedStringArray[i] + " ";
            }
            else
            {
                reversedtext += reversedStringArray[i];
            }
            return reversedtext;
        }

        private static void AddTheDelimitersAgain(List<Tuple<int, string>> delimitersAndPositions, string[] reversedStringArray)
        {
            foreach (Tuple<int, string> currentDelimiter in delimitersAndPositions)
            {
                reversedStringArray[currentDelimiter.Item1 - 1] = reversedStringArray[currentDelimiter.Item1 - 1] +
                                                                  currentDelimiter.Item2;
            }
        }

        private static List<Tuple<int, string>> RemoveDelimitersAndKeepTheirPositions(string[] textArray, string[] reversedStringArray)
        {
            var delimitersAndPositions = new List<Tuple<int, string>>();
            for (int i = 0; i < textArray.Length; i++)
            {
                string word = reversedStringArray[i];
                if (ContainsDelimiter(word))
                {
                    SaveDelimiterTypeAndPosition(textArray, reversedStringArray, i, word, delimitersAndPositions);
                }
            }
            return delimitersAndPositions;
        }

        private static void SaveDelimiterTypeAndPosition(string[] textArray, string[] reversedStringArray, int i, string word,
            List<Tuple<int, string>> delimitersAndPositions)
        {
            Tuple<int, string> currentDelimiter = new Tuple<int, string>(textArray.Length - i, word.Last().ToString());
            delimitersAndPositions.Add(currentDelimiter);
            reversedStringArray[i] = word.Substring(0, word.Length - 1);
        }

        private static string[] ReverseTextArray(string[] textArray)
        {
            string[] reversedStringArray = textArray.Reverse().ToArray();
            return reversedStringArray;
        }

        private static bool ContainsDelimiter(string word)
        {
            return word.Contains("!")||word.Contains("?")||word.Contains(",")||word.Contains(".");
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

        [TestCase("hello glorious world!", "world glorious hello!")]
        [TestCase("Hej min kära mor. Ät banan, äpple och päron!", "päron och äpple banan. Ät mor, kära min Hej!")]
        public void ReverseWordOrder_WithUnkownAmountOfWordsAndDelimitors_ReturnsTheWordsInReversedOrder(string text, string expected)
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
