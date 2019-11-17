using System.Collections.Generic;

namespace DEV_2
{
    /// <summary>
    /// This class makes transcription.
    /// </summary>
    public class TranscriptionMaker
    {
        public List<Letter> incertedString;
        public TranscriptionMaker(List<Letter> incertedString)
        {
            this.incertedString = incertedString;
        }

        /// <summary>
        /// This method returns transcription of recieved string.
        /// </summary>
        /// <returns>Transctription of word</returns>
        public List<Letter> MakeTranscription()
        {
            ReplaceUnstressedO();
            SoftenConsonants();
            ShowYotedVowelsPronunciation();
            VoiceAndDevoise();
            return incertedString;
        }

        /// <summary>
        /// This method replaces unstressed 'o' with 'a'.
        /// </summary>
        public void ReplaceUnstressedO()
        {
            foreach(Letter letter in incertedString)
            {
                if (letter is Vowel && letter.Value == "о")
                {
                    var vowel = (Vowel)letter;

                    if (!(vowel.isStressedVovel))
                    {
                        letter.Sound = "a";
                    }
                }
            }
        }

        /// <summary>
        /// This method changes sound of consonant before yoted vowels.
        /// </summary>
        public void SoftenConsonants()
        {
            for (int i = 1; i < incertedString.Count; i++) 
            {
                if(incertedString[i-1] is Consonant && incertedString[i] is Vowel)
                {
                    var vowel = (Vowel)incertedString[i];

                    if(vowel.isYoated)
                    {
                        incertedString[i - 1].Sound += "'";
                        vowel.Sound = vowel.afterConsonantSound;
                    }
                }
            }
        }

        /// <summary>
        /// This method changes sound of yoted vowels after another vowels.
        /// </summary>
        public void ShowYotedVowelsPronunciation()
        {
            for (int i = 1; i < incertedString.Count; i++)
            {
                if (i - 1 == 0 && incertedString[i - 1] is Vowel)
                {
                    var vowel = (Vowel)incertedString[i - 1];

                    if (vowel.isYoated)
                    {
                        vowel.Sound = vowel.afterVowelSound;
                    }
                }
                if ((incertedString[i - 1] is Vowel || incertedString[i - 1] is Soundless) && incertedString[i] is Vowel)
                {
                    var vowel = (Vowel)incertedString[i];

                    if (vowel.isYoated)
                    {
                        vowel.Sound = vowel.afterVowelSound;
                    }
                }
            }
        }

        /// <summary>
        /// This method changes sound of deaf and ringing consonats.
        /// </summary>
        public void VoiceAndDevoise()
        {
            for (int i = 1; i < incertedString.Count; i++)
            {
                if (incertedString[i - 1] is Consonant && incertedString[i] is Consonant)
                {
                    //Voice deaf consonant before ringing consonant.
                    var firstConsontant = (Consonant)incertedString[i - 1];
                    var secondConsontant = (Consonant)incertedString[i];

                    if (firstConsontant.isDeaf && secondConsontant.isRinging && secondConsontant.isPaired)
                    {
                        firstConsontant.Sound = firstConsontant.pair;
                    }

                    //Devoise ringing consonant before deaf consonant.
                    else if (firstConsontant.isRinging && secondConsontant.isDeaf)
                    {
                        firstConsontant.Sound = firstConsontant.pair;
                    }
                }

                /*If the word ends with voiced consonant then the devoise takes place. 
                The same goes if the word ends with "ь, ъ" after the voiced consonant*/
                else if (i == incertedString.Count - 1 && incertedString[i - 1] is Consonant && incertedString[i] is Soundless) 
                {
                    var consontant = (Consonant)incertedString[i - 1];

                    if (consontant.isRinging) 
                    {
                        consontant.Sound = consontant.pair;
                    }
                }
            }
            if (incertedString[incertedString.Count - 1] is Consonant)
            {
                var consontant = (Consonant)incertedString[incertedString.Count - 1];

                if (consontant.isRinging)
                {
                    consontant.Sound = consontant.pair;
                }
            }
        }
    }
}
