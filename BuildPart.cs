using System.Xml;
using System.Xml.Serialization;

public class BuildPart
{
    [XmlAttribute("Name")]
    public string PartName;
    public string PrefabName;

    public int RotationX;
    public int RotationY;
    public int RotationZ;

    public int PositionX;
    public int PositionY;
    public int PositionZ;

    public string DisplayData()
    {
        string outputString = "PrefabName: " + PrefabName + " Position: " + PositionX + "," + PositionY + "," +
                              PositionZ + " Rotation: " + RotationX + "," + RotationY + "," + RotationZ;
        return outputString;
    }
}
