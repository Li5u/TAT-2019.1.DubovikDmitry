namespace DEV_2
{
    /// <summary>
    /// This class keeps information about soundless letters.
    /// </summary>
    class Soundless : Letter
    {
        public Soundless(char letter)
            : base(letter)
        {
            Sound = "'";
        }
    }
}
