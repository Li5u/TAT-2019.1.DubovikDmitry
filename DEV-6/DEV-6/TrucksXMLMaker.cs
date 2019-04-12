using System.Xml.Linq;

namespace DEV_6
{
    /// <summary>
    /// Class builds xml.
    /// </summary>
    class TrucksXMLMaker
    {
        /// <summary>
        /// Builds xml document with inforamation about trucks.
        /// </summary>
        public void MakeXML()
        {
            string fileName = "TrucksStock.xml";
            XDocument doc = new XDocument(
            new XElement("TrucksStock",
                new XElement("truck",
                    new XAttribute("name", "Kamaz 1"),
                    new XAttribute("brand", "Kamaz"),
                    new XAttribute("model", "1"),
                    new XElement("count", 10),
                    new XElement("price", 30000)),

                new XElement("truck",
                    new XAttribute("name", "Kamaz 2"),
                    new XAttribute("brand", "Kamaz"),
                    new XAttribute("model", "2"),
                    new XElement("count", 3),
                    new XElement("price", 60000)),

                new XElement("truck",
                    new XAttribute("name", "Maz 1"),
                    new XAttribute("brand", "Maz"),
                    new XAttribute("model", "1"),
                    new XElement("count", 8),
                    new XElement("price", 95000)),

                new XElement("truck",
                    new XAttribute("name", "Maz 5"),
                    new XAttribute("brand", "Maz"),
                    new XAttribute("model", "5"),
                    new XElement("count", 15),
                    new XElement("price", 55000))));
            doc.Save(fileName);
        }
    }
}