using System;

namespace DEV_4
{
    /// <summary>
    /// The class for presentations.
    /// </summary>
    class Presentation : Material
    {
        public Format FormatOFPresentation { get; set; }
        private string _uri;
        public string Uri
        {
            get
            {
                return _uri;
            }
            protected set
            {
                if (value == null || value.Length == 0)
                {
                    throw new Exception("URI can't be empty!");
                }
                _uri = value;
            }
        }

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="descriprion">Description</param>
        /// <param name="format">Format</param>
        /// <param name="theme">Theme</param>
        /// <param name="uri">URI</param>
        public Presentation(string descriprion, Format format, string theme, string uri)
            : base(descriprion, theme)
        {
            FormatOFPresentation = format;
            Uri = uri;
        }

        /// <summary>
        /// The private class constructor for making deep copy of this object.
        /// </summary>
        /// <param name="description">Description</param>
        /// <param name="format">Format</param>
        /// <param name="theme">Theme</param>
        /// <param name="id">ID</param>
        private Presentation(string description, Format format, string theme, string uri, string id) 
            :this(description, format, theme, uri)
        {
            Id = id;
        }

        /// <summary>
        /// This method returns copy of Presentation object.
        /// </summary>
        /// <returns>new object of class Presentation with cloned all fields</returns>
        public object Clone()
        {
            var presentationCopy = new Presentation(this.Description, this.FormatOFPresentation, this.Theme, this.Id, this.Uri);
            return presentationCopy;
        }
    }
}
        