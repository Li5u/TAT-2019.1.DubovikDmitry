using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DEV_2.Tests
{
    [TestClass]
    class ConvertStringToLetterObjectTests
    {
        /// <summary>
        /// Checks if program give exception in case of wrong symbol.
        /// </summary>
        /// <param name="symbol">wrong symbol</param>
        [TestMethod]
        [DataRow("4")]
        [DataRow(".")]
        [DataRow("%")]
        [DataRow("-")]
        [ExpectedException(typeof(Exception), "Wrong symbol!")]
        public void ConvertStringToLetterObject_WrongSymbol_ThrowException(string symbol)
        {
            var converter = new LetterObjectConverter();
            converter.ConverStringToLetterObjectList(symbol);
        }
    }
}
