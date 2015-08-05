using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[XmlRoot("BuildModule")]
public class BuildModule {
    [XmlArray("BuildParts")]
    [XmlArrayItem("BuildPart")]
    public List<BuildPart> BuildParts = new List<BuildPart>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(BuildModule));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static BuildModule Load(string path)
    {
        var serializer = new XmlSerializer(typeof(BuildModule));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as BuildModule;
       }
    }
}
