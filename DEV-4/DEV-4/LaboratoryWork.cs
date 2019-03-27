namespace DEV_4
{
    /// <summary>
    /// Class for laboratory works
    /// </summary>
    class LaboratoryWork : Material
    {
        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="description">Description</param>
        /// <param name="theme">Theme</param>
        public LaboratoryWork(string description, string theme)
            :base(description, theme)
        { }

        /// <summary>
        /// The private class constructor for making deep copy of this object.
        /// </summary>
        /// <param name="description">Description</param>
        /// <param name="theme">Theme</param>
        /// <param name="id">ID</param>
        private LaboratoryWork(string description, string theme, string id)
            :this(description, theme)
        {
            Id = id;
        }

        /// <summary>
        /// This method returns copy of LaboratoryWork object.
        /// </summary>
        /// <returns>new object of class LaboratoryWork with cloned all fields</returns>
        public object Clone()
        {
            var laboratoryWorkCopy = new LaboratoryWork(this.Description, this.theme, this.Id);
            return laboratoryWorkCopy;
        }
    }
}
