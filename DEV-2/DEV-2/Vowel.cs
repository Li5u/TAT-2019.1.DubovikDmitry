
namespace DEV_2
{
    class Vowel
    {
        public bool isYoated = false;
        public bool isStressedVovel = false;
        public string afterConsonantSound;
        public string afterVowelSound;
        public Vowel(char letter)
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
