using System;
using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;

[ExecuteInEditMode]
public class BuildComponent : MonoBehaviour
{

    public string BuildModuleName;
    public string FileLocation;
    public bool RuntimeRebuild;
    public float BuildInterval;

    private BuildModule LocalModuleData;

	void Start () {
        LocalModuleData = new BuildModule();
	}

    public void UpdateDataFromWorld()
    {
        if (LocalModuleData == null)
        {
            LocalModuleData = new BuildModule();
        }
        else
        {
            LocalModuleData.BuildParts.Clear();
        }

        foreach (Transform child in transform)
        {
            UnityEngine.Object parentObject = PrefabUtility.GetPrefabParent(child);
            string prefabName = AssetDatabase.GetAssetPath(parentObject);
            Debug.Log("prefab path:" + prefabName);
            BuildPart temp = new BuildPart
            {
                PositionX = child.position.x,
                PositionY = child.position.y,
                PositionZ = child.position.z,
                RotationX = child.rotation.x,
                RotationY = child.rotation.y,
                RotationZ = child.rotation.z,
                PartName = child.name,
                PrefabName = prefabName
            };
            LocalModuleData.BuildParts.Add(temp);
        }
    }

    public string ReportCurrentData()
    {
        string outputString = null;
        foreach (BuildPart a in LocalModuleData.BuildParts)
        {
            outputString += " " + a.DisplayData();
        }
        return outputString;
    }

    public void LoadFromFile()
    {
        string path = Path.Combine(Application.dataPath, FileLocation + "/" + BuildModuleName);
        Debug.Log(path);
        LocalModuleData = BuildModule.Load(path);
    }

    public void SaveCurrentData()
    {
        string path = Path.Combine(Application.dataPath, FileLocation + "/" + BuildModuleName);
        Debug.Log(path);
        LocalModuleData.Save(path);
    }
}
