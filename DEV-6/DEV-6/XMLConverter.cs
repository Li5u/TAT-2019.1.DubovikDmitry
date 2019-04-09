using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DEV_6
{
    class XMLConverter
    {
        private XDocument XmlDocument { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public XMLConverter(string fileName) => XmlDocument = XDocument.Load(fileName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
