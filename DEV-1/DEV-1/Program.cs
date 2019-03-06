using System;


namespace DEV_1
{
    class Program
    {
        /// <summary>
        /// Program takes arguments from command line and displays to console
        /// all substrings without consecutive repetitive symbols
        /// </summary>
        /// <param name="args">arguments from command line</param>
        static void Main(string[] args)
        {
            SubstringSearcher searcher = new SubstringSearcher();
            string main_string = args[0];
            foreach (string substring in searcher.Find(main_string))
            {
                Console.WriteLine(substring);
            }

        }
    }
}
