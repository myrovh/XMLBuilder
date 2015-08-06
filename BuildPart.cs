using System.Xml;
using System.Xml.Serialization;

public class BuildPart
{
    [XmlAttribute("Name")]
    public string PartName;
    public string PrefabName;

    public float RotationX;
    public float RotationY;
    public float RotationZ;

    public float PositionX;
    public float PositionY;
    public float PositionZ;

    public string DisplayData()
    {
        string outputString = "PrefabName: " + PrefabName + " Position: " + PositionX + "," + PositionY + "," +
                              PositionZ + " Rotation: " + RotationX + "," + RotationY + "," + RotationZ;
        return outputString;
    }
}
