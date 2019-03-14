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
                var searcher = new TranscriptionMaker(args[0]);
                searcher.MakeTranscription();
                searcher.DisplayTranscription();
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