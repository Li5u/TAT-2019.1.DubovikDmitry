using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DEV_6
{
    class CarsStock
    {
        XDocument XmlDocument { get; }

        /// <summary>
        /// Constructor of CarsStock.
        /// </summary>
        /// <param name=name of XML></param>
        public CarsStock(string name)
        {
            string fileName = name;
            XmlDocument = XDocument.Load(fileName);
        }

        /// <summary>
        /// Method counts number of types.
        /// </summary>
        /// <returns>Number of brend</returns>
        public int CountTypes()
        {
            // Add list to save different brend.
            HashSet<string> models = new HashSet<string>();

            foreach (XElement el in XmlDocument.Root.Elements())
            {
                models.Add(el.Attribute("name").Value);
            }

            return models.Count;
        }

        public int CountCars()
        {
            int carsCounter = 0;
            foreach (XElement el in XmlDocument.Root.Elements())
            {
                carsCounter += Int32.Parse(el.Element("count").Value);
            }
            return carsCounter;
        }
    }
}
