using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SerializationExample
{
    public enum Genres
    {
        [XmlEnum(Name = "Science Fiction")]
        ScienceFiction,
        Computer,
        Fantasy,
        Romance,
        Horror
    }
 
    /// <summary>
    /// Books class with required attributes
    /// </summary>
    [Serializable]
    public class Books: ISerializable
    {             
        [XmlAttribute("id")]
        public string BookId { get; set; }
        [XmlElement("isbn")]
        public string Isbn { get; set; }
        [XmlElement("author")]
        public string Author { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("publisher")]
        public string Publisher { get; set; }
        [XmlElement("publish_date")]
        public DateTime PublishDate { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("registration_date")]
        public DateTime RegistrationDate { get; set; }
        [XmlElement("genre")]
        public Genres Genre
        {
            get; set;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id",BookId);
            info.AddValue("Isbn", Isbn);
            info.AddValue("Title", Title);
            info.AddValue("Author", Author);
            info.AddValue("Genre", Genre);
            info.AddValue("Publisher", Publisher);
            info.AddValue("Description", Description);
            info.AddValue("RegistrationDate", String.Format("{0:yyyy/MM/dd}",RegistrationDate));
            info.AddValue("PublishDate", String.Format("{0:yyyy/MM/dd}",PublishDate));
        }
    }
}
