using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ScaleControl.Models.Config;

namespace ScaleControl.Data
{
    [XmlRoot("HardwareSettings")]
    public class HardwareConfig
    {
        [XmlArray("Terminals")]
        [XmlArrayItem("Terminal")]
        public List<ScaleConnectionConfig> Terminals { get; set; }
    }

    public static class HardwareConfigLoader
    {
        public static List<ScaleConnectionConfig> Load(string configPath)
        {
            var serializer = new XmlSerializer(typeof(HardwareConfig));
            using (var reader = new StreamReader(configPath))
            {
                var config = (HardwareConfig)serializer.Deserialize(reader);
                return config.Terminals;
            }
        }

        public static void Save(List<ScaleConnectionConfig> configs, string configPath)
        {
            var serializer = new XmlSerializer(typeof(HardwareConfig));
            using (var writer = new StreamWriter(configPath))
            {
                var config = new HardwareConfig { Terminals = configs };
                serializer.Serialize(writer, config);
            }
        }
    }
}
