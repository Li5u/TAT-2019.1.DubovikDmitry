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
            if (args.Length == 0)
            {
                Console.WriteLine("Wrong input!");
            }
            else
            {
                string main_string = args[0];
                foreach (string substring in searcher.Find(main_string))
                {
                    Console.WriteLine(substring);
                }
            }

        }
    }
}
