using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_2
{
    /// <summary>
    /// This class can convert string to List of Letter objects.
    /// </summary>
    public class LetterObjectConverter
    {
        private readonly string[] _vowels = { "а", "о", "у", "ы", "э", "я", "е", "ё", "ю", "и" };
        private readonly string[] _consonants = { "б", "в", "г", "д", "й", "ж", "з", "к", "л", "м", "н",
                                                  "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" };
        private readonly string[] _soundless = { "ь", "ъ" };
        private int counterOfStressedVowels = 0; //This field is using to check stressed vowels in recieved string.

        /// <summary>
        /// his method converts all stressed vowels to upper registry.
        /// </summary>
        /// <param name="recievedString"></param>
        /// <returns>String with upper stressed vowels.</returns>D:\Work\TAT-2019\DEV-2\DEV-2\LetterObjectConverter.cs
        public StringBuilder UpperStressedVowel(StringBuilder recievedString)
        {
            var stringToReturn = recievedString;

            for (int i = 1; i < stringToReturn.Length; i++)
            {
                if ((stringToReturn[i] == '+' && stringToReturn[i - 1] != 'ё'))
                {
                    stringToReturn.Replace(stringToReturn[i - 1].ToString(), stringToReturn[i - 1].ToString().ToUpper(), i - 1, 1);
                    counterOfStressedVowels++;
                }
            }

            for (int i = 0; i < stringToReturn.Length; i++)
            {
                if (stringToReturn[i] == 'ё')
                {
                    stringToReturn.Replace(stringToReturn[i].ToString(), stringToReturn[i].ToString().ToUpper(), i, 1);
                    counterOfStressedVowels++;
                }

                //Delete '+' symbol from string.
                if (stringToReturn[i] == '+')
                {
                    stringToReturn.Remove(i, 1);
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

                for (int i = 0; i < stringToReturn.Length; i++)
                {
                    if(vowels.Contains(stringToReturn[i].ToString()))
                    {
                        counterOfVowels++;
                        stringToReturn.Replace(stringToReturn[i].ToString(), stringToReturn[i].ToString().ToUpper(), i, 1);
                    }
                }

                if (counterOfVowels > 1)
                {
                    throw new Exception ("Stressed vowel must be marked with '+'!");
                }
            }

            return stringToReturn;
        }

        /// <summary>
        /// This method converts string to List of Letter objects.
        /// </summary>
        /// <param name="recievedWord"></param>
        /// <returns>List of Letter objects</returns>
         public List<Letter> ConverStringToLetterObjectList(string recievedWord)
        {
            var recievedString = UpperStressedVowel(new StringBuilder(recievedWord));
            var letters = new List<Letter> { };

            for (int i = 0; i < recievedString.Length; i++) 
            {
                if (_consonants.Contains(recievedString[i].ToString().ToLower()))
                {
                    letters.Add(new Consonant(recievedString[i]));
                }

                else if (_vowels.Contains(recievedString[i].ToString().ToLower()))
                {
                    letters.Add(new Vowel(recievedString[i]));
                }

                else if(_soundless.Contains(recievedString[i].ToString().ToLower()))
                {
                    letters.Add(new Soundless(recievedString[i]));
                }

                else
                {
                    throw new Exception("Wrong symbol!");
                }
            }

            return letters;
        }

        /// <summary>
        /// This method displays transcription to the console.
        /// </summary>
        /// <remarks>
        /// All Letter objects has field 'sound'.
        /// This method combines all sounds and displays them to console.
        /// </remarks>
        /// <param name="incertedString">List of Letter objects</param>
        public StringBuilder DisplayTranscription(List<Letter> incertedString)
        {
            var transcription = new StringBuilder();

            foreach (var letter in incertedString)
            {
                transcription.Append(letter.Sound);
            }

            return transcription;
        }
    }
}
