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
            if(args.Length == 0)
            {
                throw new Exception("Must be an argument!");
            }

            try
            {
                var converter = new LetterObjectConverter();
                var transcriptionMaker = new TranscriptionMaker(converter.ConverStringToLetterObjectList("молоко+"));
                transcriptionMaker.ReplaceUnstressedO();
                Console.WriteLine("малако"==converter.DisplayTranscription(transcriptionMaker.incertedString).ToString());
                //var converter = new LetterObjectConverter();
                //var transcriptionSpecialist = new TranscriptionMaker(converter.ConverStringToLetterObjectList(args[0]));
                //Console.WriteLine(converter.DisplayTranscription(transcriptionSpecialist.MakeTranscription()));               
            }

            catch (Exception ex)
            {
                Console.WriteLine("Something were wrong! " + ex.Message);
            }
        }
    }
}