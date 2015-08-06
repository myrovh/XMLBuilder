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

    public void RemoveChildrenObjects()
    {
        foreach (Transform child in transform)
        {
            DestroyImmediate(child.gameObject);
        }
    }

    public void CreateChildrenObjects()
    {
        if (LocalModuleData == null) return;

        foreach (BuildPart part in LocalModuleData.BuildParts)
        {
            GameObject newGameObject = (GameObject)PrefabUtility.InstantiatePrefab(Resources.Load(part.PrefabName) as GameObject);
            newGameObject.transform.SetParent(transform);
            newGameObject.name = part.PartName;
            newGameObject.transform.localPosition = new Vector3(part.PositionX, part.PositionY, part.PositionZ);
            newGameObject.transform.rotation = Quaternion.Euler(part.RotationX, part.RotationY, part.RotationZ);
        }
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
            Vector3 eulerAngles = child.transform.rotation.eulerAngles;
            BuildPart temp = new BuildPart
            {
                PositionX = child.position.x,
                PositionY = child.position.y,
                PositionZ = child.position.z,
                RotationX = eulerAngles.x,
                RotationY = eulerAngles.y,
                RotationZ = eulerAngles.z,
                PartName = child.name,
                PrefabName = parentObject.name
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
