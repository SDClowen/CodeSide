using System.IO;
using System.Xml.Serialization;

namespace CodeSide.Plugin.Core.Helpers
{
    public class Xml
    {
        public static void Serialize<T>(T obj, string file)
        {
            using (var fileStream = new FileStream(file, FileMode.OpenOrCreate))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(fileStream, obj);
            }
        }

        public static T Deserialize<T>(string file)
        {
            using (var fileStream = new FileStream(file, FileMode.Open))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var obj = (T)xmlSerializer.Deserialize(fileStream);
                return obj;
            }
        }
    }
}
