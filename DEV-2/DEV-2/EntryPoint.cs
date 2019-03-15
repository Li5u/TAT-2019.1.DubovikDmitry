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
                var converter = new LetterObjectConverter(args[0]);
                var transcriptionSpecialist = new TranscriptionMaker(converter.ConverStringToLetterObjectList());
                converter.DisplayTranscription(transcriptionSpecialist.MakeTranscription());
                
                
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Must be an argument!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something were wrong! " + ex.Message);
            }
        }
    }
}