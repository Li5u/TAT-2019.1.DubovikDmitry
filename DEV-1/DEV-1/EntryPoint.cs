using System;


namespace DEV_1
{
    class EntryPoint
    {
        /// <summary>
        /// EntryPoint of program that takes arguments from command line and displays to console
        /// all substrings without consecutive repetitive symbols.
        /// </summary>
        /// <param name="args">Arguments from command line</param>
        static void Main(string[] args)
        {
            try
            {
                SubstringSearcher searcher = new SubstringSearcher(args[0]);
                searcher.DisplaySubstrings(searcher.FindSubstrings());
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