using System.IO;
using System.Xml.Serialization;
using ScaleControl.Models.Config;

namespace ScaleControl.Data
{
    public static class HardwareConfigLoader
    {
        public static ScaleConnectionConfig Load(string configPath)
        {
            var serializer = new XmlSerializer(typeof(ScaleConnectionConfig));
            using (var reader = new StreamReader(configPath))
            {
                return (ScaleConnectionConfig)serializer.Deserialize(reader);
            }
        }

        public static void Save(ScaleConnectionConfig config, string configPath)
        {
            var serializer = new XmlSerializer(typeof(ScaleConnectionConfig));
            using (var writer = new StreamWriter(configPath))
            {
                serializer.Serialize(writer, config);
            }
        }
    }
}
