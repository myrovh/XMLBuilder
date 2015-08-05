using System;
using UnityEngine;
using System.Collections;
using System.IO;

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

        BuildPart test = new BuildPart();
	    test.PartName = "test";
	    test.PrefabName = "test";
	    test.PositionX = 5;
	    test.PositionY = 1;
	    test.PositionZ = 1;
	    test.RotationX = 90;
	    test.RotationY = 90;
	    test.RotationZ = 90;

        LocalModuleData.BuildParts.Add(test);

        BuildPart test2 = new BuildPart();
	    test2.PartName = "test2";
	    test2.PositionX = 5;
	    test2.PositionY = 1;
	    test2.PositionZ = 1;

        LocalModuleData.BuildParts.Add(test2);
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
