using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_2
{
    class LetterObjectConverter
    {
        private int counterOfStressedVowels = 0;
        private StringBuilder recievedString;
        private string RecievedString
        {
            set
            {
                this.recievedString = new StringBuilder(value.ToLower());
            }
        }

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="resievedString"></param>
        public LetterObjectConverter(string recievedString)
        {
            RecievedString = recievedString;
        }

        private void UpperStressedVowel()
        {
            for (int i = 1; i < recievedString.Length; i++)
            {
                if ((recievedString[i] == '+' && recievedString[i - 1] != 'ё'))
                {
                    recievedString.Replace(recievedString[i - 1].ToString(), recievedString[i - 1].ToString().ToUpper(), i - 1, 1);
                    counterOfStressedVowels++;
                }
            }
            for (int i = 0; i < recievedString.Length; i++)
            {
                if (recievedString[i] == 'ё')
                {
                    recievedString.Replace(recievedString[i].ToString(), recievedString[i].ToString().ToUpper(), i, 1);
                    counterOfStressedVowels++;
                }
                if (recievedString[i] == '+')
                {
                    recievedString.Remove(i, 1);
                }
            }
            if (counterOfStressedVowels > 1)
            {
                throw new Exception("To many stressed vowels!");
            }
            if (counterOfStressedVowels == 0)
            {
                int counterOfVowels = 0;
                string[] vowels = { "а", "о", "у", "ы", "э", "я", "е", "ё", "ю", "и" };
                for (int i = 0; i < recievedString.Length; i++)
                {
                    if(vowels.Contains(recievedString[i].ToString()))
                    {
                        counterOfVowels++;
                        recievedString.Replace(recievedString[i].ToString(), recievedString[i].ToString().ToUpper(), i, 1);
                    }
                }
                if (counterOfVowels > 1)
                {
                    throw new Exception ("Stresse vowel must be marked with '+'!");
                }
            }
        }

        public List<Letter> ConverStringToLetterObjectList()
        {
            UpperStressedVowel();
            var letters = new List<Letter> { };
            for (int i = 0; i < recievedString.Length; i++) 
            {
                letters.Add(new Letter(recievedString[i]));
            }
            return letters;
        }

        /// <summary>
        /// This method displays transcription to the console.
        /// </summary>
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
