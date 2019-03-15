using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_2
{
    /// <summary>
    /// This class can convert string to List of Letter objects.
    /// </summary>
    class LetterObjectConverter
    {
        private int counterOfStressedVowels = 0; //This field is using to check stressed vowels in recieved string.

        /// <summary>
        /// This method converts all stressed vowels to upper registry.
        /// </summary>
        /// <param name="receievedString"></param>
        private void UpperStressedVowel(StringBuilder receievedString)
        {
            
            for (int i = 1; i < receievedString.Length; i++)
            {
                if ((receievedString[i] == '+' && receievedString[i - 1] != 'ё'))
                {
                    receievedString.Replace(receievedString[i - 1].ToString(), receievedString[i - 1].ToString().ToUpper(), i - 1, 1);
                    counterOfStressedVowels++;
                }
            }
            for (int i = 0; i < receievedString.Length; i++)
            {
                if (receievedString[i] == 'ё')
                {
                    receievedString.Replace(receievedString[i].ToString(), receievedString[i].ToString().ToUpper(), i, 1);
                    counterOfStressedVowels++;
                }
                //Delete '+' symbol from string.
                if (receievedString[i] == '+')
                {
                    receievedString.Remove(i, 1);
                }
            }
            if (counterOfStressedVowels > 1)
            {
                throw new Exception("To many stressed vowels!");
            }
            /*In case if program can't find stressed vowels('ё' or vowels before '+') 
             *  it makes all vowels stressed and count them.*/
            if (counterOfStressedVowels == 0)
            {
                int counterOfVowels = 0;
                string[] vowels = { "а", "о", "у", "ы", "э", "я", "е", "ё", "ю", "и" };
                for (int i = 0; i < receievedString.Length; i++)
                {
                    if(vowels.Contains(receievedString[i].ToString()))
                    {
                        counterOfVowels++;
                        receievedString.Replace(receievedString[i].ToString(), receievedString[i].ToString().ToUpper(), i, 1);
                    }
                }
                if (counterOfVowels > 1)
                {
                    throw new Exception ("Stressed vowel must be marked with '+'!");
                }
            }
        }

        /// <summary>
        /// This method converts string to List of Letter objects.
        /// </summary>
        /// <param name="recievedWord"></param>
        /// <returns>List of Letter objects</returns>
        public List<Letter> ConverStringToLetterObjectList(string recievedWord)
        {
            var recievedString = new StringBuilder(recievedWord);
            UpperStressedVowel(recievedString);
            var letters = new List<Letter> { };
            for (int i = 0; i < recievedString.Length; i++) 
            {
                letters.Add(new Letter(recievedString[i]));
            }
            return letters;
        }

        /// <summary>
        /// his method displays transcription to the console.
        /// </summary>
        /// <remarks>
        /// All Letter objects has field 'sound'.
        /// This method combines all sounds and displays them to console.
        /// </remarks>
        /// <param name="incecredString">List of Letter objects</param>
        public void DisplayTranscription(List<Letter> incecredString)
        {
            var transcription = new StringBuilder();
            foreach (var letter in incecredString)
            {
                transcription.Append(letter.sound);
            }
            Console.WriteLine(transcription);
        }
    }
}
