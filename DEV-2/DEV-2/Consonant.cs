using System.Linq;

namespace DEV_2
{
    /// <summary>
    /// This class keeps information about consonant letters.
    /// </summary>
    class Consonant
    {
        public bool isRinging = false;
        public bool isDeaf = false;
        public string pair;

        /// <summary>
        /// The class constructor verifies consonant letter with his base 
        /// and after that sets letter fields.
        /// </summary>
        /// <param name="letter"></param>
        public Consonant(char letter)
        {
            string[,] pairedConsonant = { { "б", "п" }, { "в", "ф" }, { "г", "к" }, { "д", "т" }, { "ж", "ш" }, { "з", "с" } };
            string[] alwaysRinging = { "л", "м", "н", "р", "й" };
            string[] alwaysDeaf = { "х", "ц", "ч", "щ" };
            if (alwaysRinging.Contains(letter.ToString().ToLower()))
            {
                this.isRinging = true;
                this.pair = letter.ToString();
            }
            if (alwaysDeaf.Contains(letter.ToString().ToLower()))
            {
                this.isDeaf = true;
                this.pair = letter.ToString();
            }
            for (int i = 0; i < pairedConsonant.GetLength(0); i++)
            {
                if (letter.ToString().ToLower() == pairedConsonant[i, 0])
                {
                    this.isRinging = true;
                    this.pair = pairedConsonant[i, 1];
                    break;
                }
                else if (letter.ToString().ToLower() == pairedConsonant[i, 1])
                {
                    this.isDeaf = true;
                    this.pair = pairedConsonant[i, 0];
                    break;
                }
            }
        }
    }
}