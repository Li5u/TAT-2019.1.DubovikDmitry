using System;

namespace DEV_2
{
    class EntryPoint
    {
        /// <summary>
        ///EntryPoint of program that takes string from command line 
        ///and displays to console transcription of this string.
        /// </summary>
        /// <param name="args">Arguments from command line</param>
        static void Main(string[] args)
        {
            try
            {
                var converter = new LetterObjectConverter();
                var transcriptionSpecialist = new TranscriptionMaker(converter.ConverStringToLetterObjectList(args[0]));
                converter.DisplayTranscription(transcriptionSpecialist.MakeTranscription());               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something were wrong! " + ex.Message);
            }
        }
    }
}