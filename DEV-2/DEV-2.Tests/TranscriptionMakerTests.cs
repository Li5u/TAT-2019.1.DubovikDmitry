
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DEV_2.Tests
{
    [TestClass]
    public class TranscriptionMakerTests
    {
        /// <summary>
        /// Checks if ReplaceUnstressedO method replaces unstressed 'o' with 'a'.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
        [TestMethod]
        [DataRow("молоко+", "малако")]
        [DataRow("полено+", "палено")]
        [DataRow("о+", "о")]
        [DataRow("о", "а")]
        public void ReplaceUnstressedOTest(string input, string expected)
        {
            var converter = new LetterObjectConverter();
            var transcriptionMaker = new TranscriptionMaker(converter.ConverStringToLetterObjectList(input));

            transcriptionMaker.ReplaceUnstressedO();

            Assert.AreEqual(expected, converter.DisplayTranscription(transcriptionMaker.incertedString).ToString());
        }

        /// <summary>
        /// Checks if SoftenConsonats method changes sound of consonant before yoted vowels.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
        [TestMethod]
        [DataRow("ме+сто", "м'эста")]
        [DataRow("тря+пка", "тр'апка")]
        public void SoftenConsonantsTest(string input, string expected)
        {
            var converter = new LetterObjectConverter();
            var transcriptionMaker = new TranscriptionMaker(converter.ConverStringToLetterObjectList(input));

            transcriptionMaker.SoftenConsonants();

            Assert.AreEqual(expected, converter.DisplayTranscription(transcriptionMaker.incertedString).ToString());
        }

        /// <summary>
        /// Checks if ShowYotedVowelsPronunciation method changes sound of yoted vowels after another vowels.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
        [TestMethod]
        [DataRow("ёлка", "йолка")]
        [DataRow("вью+га", "в’йуга")]
        public void ShowYotedVowelsPronunciationTest(string input, string expected)
        {
            var converter = new LetterObjectConverter();
            var transcriptionMaker = new TranscriptionMaker(converter.ConverStringToLetterObjectList(input));

            transcriptionMaker.ShowYotedVowelsPronunciation();

            Assert.AreEqual(expected, converter.DisplayTranscription(transcriptionMaker.incertedString).ToString());
        }

        /// <summary>
        /// Checks if VoiceAndDevoise method changes sound of deaf and ringing consonats.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
        [TestMethod]
        [DataRow("сде+лать", "зд’элат’")]
        [DataRow("зуб", "зуп")]
        public void VoiceAndDevoiseTest(string input, string expected)
        {
            var converter = new LetterObjectConverter();
            var transcriptionMaker = new TranscriptionMaker(converter.ConverStringToLetterObjectList(input));

            transcriptionMaker.VoiceAndDevoise();

            Assert.AreEqual(expected, converter.DisplayTranscription(transcriptionMaker.incertedString).ToString());
        }
    }
}
