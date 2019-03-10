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
                Console.WriteLine("Must be at least one argument!");
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    string main_string = args[i];
                    if (main_string.Length < 2)
                    {
                        Console.WriteLine($"Incorrect string \"{main_string}\"! String lenght must be two or more");
                    }
                    else
                    {
                        Console.WriteLine($"Substrings in \"{main_string}\":");
                        foreach (string substring in searcher.Find(main_string))
                        {
                            Console.WriteLine(substring);
                        }
                    }
                }
            }

        }
    }
}
