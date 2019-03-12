using System;
using System.Collections.Generic;
using System.Text;


namespace DEV_1
{   /// <summary>
    /// Class can find and display substrings without consecutive repetitive symbols.
    /// </summary>
    class SubstringSearcher
    {
        private string recievedString;
        /// <summary>
        /// The class constructor checks if argument from command line is valid.
        /// </summary>
        /// <param name="recievedString">Argument from command line</param>
        public SubstringSearcher(string recievedString)
        {
            if (recievedString.Length < 2 || recievedString == null)
            {
                throw new Exception($"Incorrect string \"{recievedString}\"! String lenght must be more than one symbol.");
            }
            this.recievedString = recievedString;
        }

        /// <summary>
        /// This method returns HashSet of substrings without consecutive repetitive symbols.
        /// </summary>
        public HashSet<string> FindSubstrings()
        {
            HashSet<string> substrings = new HashSet<string>();
            for (int i = 0; i < recievedString.Length; i++)
            {
                StringBuilder currentSubstring = new StringBuilder(recievedString[i].ToString());
                for (int j = i + 1; j < recievedString.Length; j++)
                {
                    if (recievedString[j - 1] != recievedString[j])
                    {
                        currentSubstring.Append(recievedString[j]);
                        //HashSet won't add current_substring if it also exists.
                        substrings.Add(currentSubstring.ToString());
                        continue;
                    }
                    break;
                }
            }
            return substrings;
        }

        /// <summary>
        /// This method displays substrings without consecutive repetitive symbols.
        /// </summary>
        public void DisplaySubstrings(HashSet<string> substrings)
        {
            Console.WriteLine($"Substrings in \"{recievedString}\":");
            foreach (string substring in substrings)
            {
                Console.WriteLine(substring);
            }
        }
    }
}