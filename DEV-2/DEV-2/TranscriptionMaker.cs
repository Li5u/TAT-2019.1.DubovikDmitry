using System.Collections.Generic;

namespace DEV_2
{
    /// <summary>
    /// This class makes transcription.
    /// </summary>
    class TranscriptionMaker
    {
        private List<Letter> incertedString;
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
        private void ReplaceUnstressedO()
        {
            foreach(Letter letter in incertedString)
            {
                if(letter.value == "о")
                {
                    if(!letter.vowelType.isStressedVovel)
                    {
                        letter.sound = "a";
                    }
                }
            }
        }

        /// <summary>
        /// This method changes sound of consonant before yoted vowels.
        /// </summary>
        private void SoftenConsonants()
        {
            for (int i = 1; i < incertedString.Count; i++) 
            {
                if(incertedString[i-1].isCosontans && incertedString[i].isVowel)
                {
                    if(incertedString[i].vowelType.isYoated)
                    {
                        incertedString[i - 1].sound += "'";
                        incertedString[i].sound = incertedString[i].vowelType.afterConsonantSound;
                    }
                }
            }
        }

        /// <summary>
        /// This method changes sound of yoted vowels after another vowels.
        /// </summary>
        private void ShowYotedVowelsPronunciation()
        {
            for (int i = 1; i < incertedString.Count; i++)
            {
                if (i - 1 == 0 && incertedString[i - 1].isVowel)
                {
                    if (incertedString[i - 1].vowelType.isYoated)
                    {
                        incertedString[i - 1].sound = incertedString[i].vowelType.afterVowelSound;
                    }
                }
                if ((incertedString[i - 1].isVowel || incertedString[i - 1].isSoundless) && incertedString[i].isVowel)
                {
                    if (incertedString[i].vowelType.isYoated)
                    {
                        incertedString[i].sound = incertedString[i].vowelType.afterVowelSound;
                    }
                }
            }
        }

        /// <summary>
        /// This method changes sound of deaf and ringing consonats.
        /// </summary>
        private void VoiceAndDevoise()
        {
            for (int i = 1; i < incertedString.Count; i++)
            {
                if(incertedString[i-1].isCosontans && incertedString[i].isCosontans)
                {
                    if(incertedString[i-1].consontantType.isDeaf && incertedString[i].consontantType.isRinging)
                    {
                        incertedString[i - 1].sound = incertedString[i - 1].consontantType.pair;
                    }
                    else if(incertedString[i-1].consontantType.isRinging && incertedString[i].consontantType.isDeaf)
                    {
                        incertedString[i - 1].sound = incertedString[i - 1].consontantType.pair;
                    }
                }
            }
            if (incertedString[incertedString.Count - 1].isCosontans)
            {
                if(incertedString[incertedString.Count - 1].consontantType.isRinging)
                {
                    incertedString[incertedString.Count - 1].sound = incertedString[incertedString.Count - 1].consontantType.pair;
                }
            }
        }
    }
}
