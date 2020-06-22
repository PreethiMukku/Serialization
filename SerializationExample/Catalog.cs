using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationExample
{
    /// <summary>
    /// Catalog Class which has Books
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "catalog", Namespace = "http://library.by/catalog")]   
    public class Catalog: ISerializable
    {
        public Catalog() { }
        [XmlAttribute(AttributeName ="date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "book")]
        public Books[] Books { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Date",Date);
            info.AddValue("Book",Books);
        }
    }
}
