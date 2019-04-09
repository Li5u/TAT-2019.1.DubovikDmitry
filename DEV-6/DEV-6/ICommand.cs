namespace DEV_6
{
    /// <summary>
    /// Interface for pattern commands.
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// Interface method.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        int Execute();
    }
}
