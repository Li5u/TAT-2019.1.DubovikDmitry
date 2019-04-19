namespace DEV_2
{
    /// <summary>
    /// This class keeps information about vowels letters.
    /// </summary>
    /// <remarks>
    /// Stressed vowels must be in upper registry.
    /// </remarks>
    class Vowel : Letter
    {
        internal bool isYoated = false; //'а','я','е','ё' are yoted.
        internal bool isStressedVovel = false;
        internal string afterConsonantSound;
        internal string afterVowelSound;

        /// <summary>
        /// The class constructor verifies vowel letter with his base 
        /// and after that sets letter fields.
        /// </summary>
        /// <param name="letter"></param>
        public Vowel(char letter)
            :base(letter)
        {
            string[,] yoatedVowels = { { "ю", "у", "йу" }, { "я", "а", "йа" }, { "ё", "о", "йо" }, { "е", "э", "йэ" } };
            this.afterConsonantSound = letter.ToString().ToLower();
            this.afterVowelSound = letter.ToString().ToLower();
            for (int i = 0; i < yoatedVowels.GetLength(0); i++)
            {
                if (letter.ToString().ToLower() == yoatedVowels[i, 0])
                {
                    this.isYoated = true;
                    this.afterConsonantSound = yoatedVowels[i, 1];
                    this.afterVowelSound = yoatedVowels[i, 2];
                }
            }
            if (letter.ToString() != letter.ToString().ToLower())
            {
                this.isStressedVovel = true;
            }
        }
    }
}
