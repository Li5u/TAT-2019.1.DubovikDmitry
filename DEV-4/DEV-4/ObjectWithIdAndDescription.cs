using System;

namespace DEV_4
{
    /// <summary>
    /// Abstract class for all objects that have id and description.
    /// </summary>
    class ObjectWithIdAndDescription
    {
        public string Id { get; protected set; }
        public string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value.Length > 256)
                {
                    throw new Exception("To long discription!");
                }
                description = value;
            }
        }

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="description">Description</param>
        public ObjectWithIdAndDescription(string description)
        {
            Id = Id.GetId();
            Description = description;
        }

        /// <summary>
        /// Overrided ToString method returns description of material.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Description;
        }

        /// <summary>
        /// Overrided Equals method returns true if objects have same ids.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            ObjectWithIdAndDescription m = obj as ObjectWithIdAndDescription; // return null if object can't be presented as Material.
            if (m as ObjectWithIdAndDescription == null)
            {
                return false;
            }
            return m.Id == this.Id;
        }
    }
}
