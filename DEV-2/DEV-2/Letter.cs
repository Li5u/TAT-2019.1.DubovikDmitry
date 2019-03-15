using System;
using System.Linq;

namespace DEV_2
{
    /// <summary>
    /// This class keeps all information about letters.
    /// </summary>
    class Letter
    {
        public readonly string value;
        public string sound;
        public bool isCosontans = false;
        public bool isVowel = false;
        public bool isSoundless = false;
        public Vowel vowelType = null;
        public Consonant consontantType = null;

        /// <summary>
        /// The class constructor verifies letter with his base 
        /// and after that sets letter fields.
        /// </summary>
        /// <param name="letter"></param>
        public Letter(char letter)
        {
            string[] vowels = { "а", "о", "у", "ы", "э", "я", "е", "ё", "ю", "и" };
            string[] consonants = { "б", "в", "г", "д", "й", "ж", "з", "к", "л", "м", "н",
                                                 "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" };
            string[] soundless = { "ь", "ъ" };
            if (consonants.Contains(letter.ToString().ToLower()))
            {
                this.isCosontans = true;
                this.consontantType = new Consonant(letter);
                this.value = letter.ToString().ToLower();
                this.sound = letter.ToString().ToLower();
            }
            else if (vowels.Contains(letter.ToString().ToLower()))
            {
                this.isVowel = true;
                this.vowelType = new Vowel(letter);
                this.value = letter.ToString().ToLower();
                this.sound = letter.ToString().ToLower();
            }
            else if (soundless.Contains(letter.ToString().ToLower()))
            {
                this.isSoundless = true;
                this.value = letter.ToString().ToLower();
                this.sound = "'";
            }
            else
            {
                throw new Exception("Wrong symbol!");
            }

        }
    }
}
