using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DEV_6
{

    /// <summary>
    /// This class parse xml document.
    /// </summary>
    class XMLConverter
    {
        private XDocument XmlDocument { get; set; }

        /// <summary>
        /// Constructor initializes fields.
        /// </summary>
        /// <param name="fileName">Filename</param>
        public XMLConverter(string fileName) => XmlDocument = XDocument.Load(fileName);

        /// <summary>
        /// Returns cars list according to xml document.
        /// </summary>
        /// <returns>List of cars</returns>
        public List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();
            foreach (XElement el in XmlDocument.Root.Elements())
            {
                for (int i = 0; i < Int32.Parse(el.Element("count").Value); i++)
                {
                    cars.Add(new Car(el.Attribute("name").Value,
                                     el.Attribute("brand").Value,
                                     el.Attribute("model").Value,
                                     Int32.Parse(el.Element("price").Value)));
                }
            }
            return cars;
        }
    }
}
