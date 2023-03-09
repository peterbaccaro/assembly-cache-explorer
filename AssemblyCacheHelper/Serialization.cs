using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AssemblyCacheHelper
{
    public class Serialization
    {
        public static T DeserializeObject<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            MemoryStream w = new MemoryStream(StringToUTF8ByteArray(xml));
            XmlTextWriter writer = new XmlTextWriter(w, Encoding.UTF8);
            return (T)serializer.Deserialize(w);
        }

        public static string SerializeObject<T>(T obj)
        {
            try
            {
                MemoryStream w = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextWriter writer = new XmlTextWriter(w, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                serializer.Serialize((XmlWriter)writer, obj);
                w = (MemoryStream)writer.BaseStream;
                return UTF8ByteArrayToString(w.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }

        private static byte[] StringToUTF8ByteArray(string pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(pXmlString);
        }

        private static string UTF8ByteArrayToString(byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(characters);
        }
    }
}

