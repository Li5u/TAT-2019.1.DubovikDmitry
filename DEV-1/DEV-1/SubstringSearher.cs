using System;
using System.Collections.Generic;


namespace DEV_1
{   /// <summary>
    /// Class can find substrings without consecutive repetitive symbols
    /// </summary>
    public class SubstringSearcher
    {
        /// <summary>
        /// returns HashSet of substrings
        /// </summary>
        public HashSet<string> Find(string main_string)
        {
            HashSet<string> substrings = new HashSet<string>();
            if (main_string.Length < 2)
            {
                Console.WriteLine("Wrong input!");
                return substrings;
            }
            else
            {
                for (int i = 0; i < main_string.Length; i++)
                {
                    string current_substring = main_string[i].ToString();
                    for (int j = i + 1; j < main_string.Length; j++)
                    {
                        if (main_string[j - 1] != main_string[j])
                        {
                            current_substring += main_string[j];
                            substrings.Add(current_substring);
                            //HashSet won't add current_substring if it also exists
                            continue;
                        }
                        else
                            break;
                    }
                }
                return substrings;
            }
        }
    }
}
