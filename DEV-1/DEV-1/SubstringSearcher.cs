using System;
using System.Collections.Generic;


namespace DEV_1
{   /// <summary>
    /// Class can find and display substrings without consecutive repetitive symbols
    /// </summary>
    class SubstringSearcher
    {
        private string main_string;
        public SubstringSearcher(string argument)
        {
            if (argument.Length < 2 || argument == null)
            {
                throw new Exception($"Incorrect string \"{argument}\"! String lenght must be more than one symbol");
            }
            else
            {
                main_string = argument;
            }
        }

        /// <summary>
        /// This method returns HashSet of substrings without consecutive repetitive symbols
        /// </summary>
        public HashSet<string> FindSubstrings()
        {
            HashSet<string> substrings = new HashSet<string>();
            for (int i = 0; i < main_string.Length; i++)
            {
                string current_substring = main_string[i].ToString();
                for (int j = i + 1; j < main_string.Length; j++)
                {
                    if (main_string[j - 1] != main_string[j])
                    {
                        current_substring += main_string[j];
                        substrings.Add(current_substring);//HashSet won't add current_substring if it also exists
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return substrings;
        }

        /// <summary>
        /// This method displays substrings without consecutive repetitive symbols
        /// </summary>
        public void DisplaySubstrings(HashSet<string> substrings)
        {
            Console.WriteLine($"Substrings in \"{main_string}\":");
            foreach(string substring in substrings)
            {
                Console.WriteLine(substring);
            }
        }        
    }
}
