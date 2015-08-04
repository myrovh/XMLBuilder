using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("BuildModule")]
public class BuildModule {
    [XmlArray("BuildParts")]
    [XmlArrayItem("BuildPart")]
    public List<BuildPart> BuildParts = new List<BuildPart>(); 
}
