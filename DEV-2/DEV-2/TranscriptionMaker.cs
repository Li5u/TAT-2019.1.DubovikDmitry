using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_2
{
    class TranscriptionMaker
    {
        private readonly string[,] vowels = { { "ю", "у", "йу" }, { "я", "а", "йа" }, { "ё", "о", "йо" }, { "е", "э", "йэ" } };
        private readonly char[] consonants = { 'б', 'в', 'г', 'д', 'й', 'ж', 'з', 'к', 'л', 'м', 'н',
                                                 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
        private readonly char[] soundless = { 'ь', 'ъ' };
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
        public TranscriptionMaker(string recievedString)
        {
            RecievedString = recievedString;
        }

        /// <summary>
        /// This method returns transcription of resieved string.
        /// </summary>
        public StringBuilder MakeTranscription()
        {
            ReplaceUnstressedO();
            SoftenConstans();
            return recievedString;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReplaceUnstressedO()
        {
            recievedString.Replace('о', 'а');
            for (int i = 1; i < recievedString.Length; i++)
            {
                if(recievedString[i-1] == 'а' && recievedString[i] == '+')
                {
                    recievedString.Replace('а', 'о', i - 1, 1);
                }
                if(recievedString[i]== '+')
                {
                    recievedString.Remove(i, 1);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SoftenConstans()
        {
            for (int i = 1; i < recievedString.Length; i++) 
            {
                for (int j = 0; j < vowels.GetLength(0); j++)
                {
                    if (consonants.Contains(recievedString[i - 1]) && recievedString[i].ToString() == vowels[j, 0]) 
                    {
                        recievedString.Insert(i, "'", 1);
                        recievedString.Replace(recievedString[i + 1].ToString(), vowels[j, 1], i + 1, 1);
                        i++;
                    }
                }
            }
        }


        /// <summary>
        /// This method displays transcription to the console.
        /// </summary>
        public void DisplayTranscription()
        {
            Console.WriteLine(recievedString);
        }

    }
}
