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
                for (int i = 0; i < args.Length; i++)
                {
                    string main_string = args[i];
                    Console.WriteLine($"Substrings of {main_string}:");
                    foreach (string substring in searcher.Find(main_string))
                    {
                        Console.WriteLine(substring);
                    }
                }
            }

        }
    }
}
