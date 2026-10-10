using System.IO;
using System.Xml.Serialization;
using ScaleControl.Models.Config;

namespace ScaleControl.Data
{
    public static class DatabaseConfigLoader
    {
        public static DatabaseConfig Load(string configPath)
        {
            var serializer = new XmlSerializer(typeof(DatabaseConfig));
            using (var reader = new StreamReader(configPath))
            {
                return (DatabaseConfig)serializer.Deserialize(reader);
            }
        }

        public static void Save(DatabaseConfig config, string configPath)
        {
            var serializer = new XmlSerializer(typeof(DatabaseConfig));
            using (var writer = new StreamWriter(configPath))
            {
                serializer.Serialize(writer, config);
            }
        }
    }
}
