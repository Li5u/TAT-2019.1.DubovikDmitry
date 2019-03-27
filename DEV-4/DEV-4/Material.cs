using System;

namespace DEV_4
{
    /// <summary>
    /// Abstract class for all materials/
    /// </summary>
    abstract class Material : ObjectWithIdAndDescription
    {
        public string theme;
        public string Theme
        {
            get
            {
                return theme;
            }
            set
            {
                if (value.Length > 100)
                {
                    throw new Exception("To long theme!");
                }
                theme = value;
            }
        }

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="description">Description</param>
        /// <param name="theme">Theme</param>
        public Material(string description, string theme)
            :base(description)
        {
            Theme = theme;
        }
    }
}
