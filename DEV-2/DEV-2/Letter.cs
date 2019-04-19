namespace DEV_2
{
    /// <summary>
    /// This class keeps all information about letters.
    /// </summary>
    class Letter
    {
        internal string Value { get; set; }
        internal string Sound { get; set; }

        /// <summary>
        /// The class constructor verifies letter with his base 
        /// and after that sets letter fields.
        /// </summary>
        /// <param name="letter"></param>
        public Letter(char letter)
        {
            Value = letter.ToString().ToLower();
            Sound = letter.ToString().ToLower();
        }
    }
}
