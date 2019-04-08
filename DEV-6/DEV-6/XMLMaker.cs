using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DEV_6
{
    class XMLMaker
    {
        public void MakeXML()
        {
            string fileName = "CarsStock.xml";
            XDocument doc = new XDocument(
            new XElement("CarsStock",
                new XElement("car",
                    new XAttribute("name", "Ford Focus"),
                    new XAttribute("brand", "Ford"),
                    new XAttribute("model", "Focus"),
                    new XElement("count", 10),
                    new XElement("price", 10000)),

                new XElement("car",
                    new XAttribute("name", "Ford Mustang"),
                    new XAttribute("brand", "Ford"),
                    new XAttribute("model", "Mustang"),
                    new XElement("count", 3),
                    new XElement("price", 30000)),

                new XElement("car",
                    new XAttribute("name", "Audi a8"),
                    new XAttribute("brand", "Audi"),
                    new XAttribute("model", "a8"),
                    new XElement("count", 7),
                    new XElement("price", 15000)),

                new XElement("car",
                    new XAttribute("name", "BMW X3"),
                    new XAttribute("brand", "BMW"),
                    new XAttribute("model", "X3"),
                    new XElement("count", 15),
                    new XElement("price", 12000))));
            doc.Save(fileName);
        }
    }
}