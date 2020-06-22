using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SerializationExample
{
    /// <summary>
    /// Main Program
    /// </summary>
    class Program
    {
        private static Catalog _catalogXml = null;
        public static void Main(string[] args)
        {         
            XmlDeSerialization();
            JsonSerialization();
        }

        /// <summary>
        /// Method to perform JsonSerialization of XmlDocument
        /// </summary>
        private static void JsonSerialization()
        {
            try
            {   Console.WriteLine("---------JSON Data----------");          
                var jsonData = JsonConvert.SerializeObject(_catalogXml, Newtonsoft.Json.Formatting.Indented);
                Console.WriteLine(jsonData);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }           
        }

        /// <summary>
        /// Method to perform DeSerialization of XmlDocument
        /// </summary>
        private static void XmlDeSerialization()
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Catalog));
                StreamReader streamReader = new StreamReader(@"../../books.xml");
                _catalogXml = (Catalog)deserializer.Deserialize(streamReader);
                StringBuilder content = new StringBuilder();
                for (int i = 0; i < _catalogXml.Books.Length; i++)
                {
                    content.Append("\tBook Id: " + _catalogXml.Books[i].BookId+"\n");
                    content.Append("\tAuthor: " + _catalogXml.Books[i].Author+"\n");
                    content.Append("\tIsbn: " + _catalogXml.Books[i].Isbn+"\n");
                    content.Append("\tTitle: " + _catalogXml.Books[i].Title+ "\n");
                    content.Append("\tDescription: " + _catalogXml.Books[i].Description+ "\n");
                    content.Append("\tPublisher: " + _catalogXml.Books[i].Publisher+ "\n");
                    content.Append("\tGenre: " + _catalogXml.Books[i].Genre+ "\n");
                    content.Append("\tPublishe Date: " + String.Format("{0:yyyy/MM/dd}", _catalogXml.Books[i].PublishDate)+ "\n");
                    content.Append("\tRegistration Date: " + String.Format("{0:yyyy/MM/dd}", _catalogXml.Books[i].RegistrationDate)+ "\n");
                    content.Append("--------------------------------------------------\n");
                }
                Console.WriteLine(content);
                streamReader.Close();           
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }          
        }
    }
}
