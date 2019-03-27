using System;

namespace DEV_4
{
    /// <summary>
    /// Class for lectures.
    /// </summary>
    class Lecture : Material
    {
        public string textOfTheLecture;
        public string TextOfTheLecture
        {
            get
            {
                return textOfTheLecture;
            }
            protected set
            {
                if (value.Length > 100000)
                {
                    throw new Exception("To long lection!");
                }
                textOfTheLecture = value;
            }
        }
        public Presentation presentation;

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="textOfTheLection">Test of the lection</param>
        /// <param name="description">Description</param>
        /// <param name="theme">theme</param>
        /// <param name="presentation">Presentation object</param>
        public Lecture(string textOfTheLection, string description, string theme, Presentation presentation)
            :base(description, theme)
        {
            TextOfTheLecture = textOfTheLection;
            this.presentation = presentation;
        }

        /// <summary>
        /// The private class constructor for making deep copy of this object.
        /// </summary>
        /// <param name="textOfTheLection">Text of the lecture</param>
        /// <param name="description">Description</param>
        /// <param name="theme">Theme</param>
        /// <param name="presentation">Presentation object</param>
        /// <param name="id">ID</param>
        private Lecture(string textOfTheLection, string description, string theme, Presentation presentation, string id)
            : this(textOfTheLection, description, theme, presentation)
        {
            this.presentation = (Presentation)presentation.Clone();
            Id = id;
        }

        /// <summary>
        /// This method returns copy of Lecture object.
        /// </summary>
        /// <returns>new object of class Lecture with cloned all fields</returns>
        public object Clone()
        {
            var lectureCopy = new Lecture(this.TextOfTheLecture, this.Description, this.Theme, this.presentation, this.Id);
            return lectureCopy;
        }
    }
}
