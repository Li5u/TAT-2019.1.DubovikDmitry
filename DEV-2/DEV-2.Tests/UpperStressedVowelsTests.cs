using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace DEV_2.Tests
{
    [TestClass]
    public class UpperStressedVowelsTests
    {
        /// <summary>
        /// Checks if UpperStressedVowel method converts all stressed vowels to upper registry.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
        [TestMethod]
        [DataRow("молоко+", "молокО")]
        [DataRow("ёлка", "Ёлка")]
        [DataRow("кол", "кОл")]
        public void UpperStressedVowel_SomeWord_StressedVowelInUpperRegistry(string input, string expected)
        {
            var recievedString = new StringBuilder(input);

            var converter = new LetterObjectConverter();

            Assert.AreEqual(expected, converter.UpperStressedVowel(recievedString).ToString());
        }

        /// <summary>
        /// Checks if UpperStressedVowel method  give exception in case of wrong input(to many "+").
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "To many stressed vowels!")]
        public void UpperStressedVowel_ToManyPluses_ThrowException()
        {
            var converter = new LetterObjectConverter();
            converter.UpperStressedVowel(new StringBuilder("сло+во+"));
        }

        /// <summary>
        /// Checks if UpperStressedVowel method  give exception in case of wrong input(stressed vowels must be marked with "+").
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "Stressed vowel must be marked with '+'!")]
        public void UpperStressedVowel_NoPlusesButManyVowels_ThrowException()
        {
            var converter = new LetterObjectConverter();
            converter.UpperStressedVowel(new StringBuilder("слово"));
        }
    }
}
