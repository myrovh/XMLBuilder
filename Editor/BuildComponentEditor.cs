using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildComponent))]
class BuildComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BuildComponent component = (BuildComponent) target;

        DrawDefaultInspector();

        if (GUILayout.Button("Create New Template"))
        {
            component.UpdateDataFromWorld();
            component.SaveCurrentData();
            Debug.Log("New Template Created");
        }

        if (GUILayout.Button("Test Load"))
        {
            component.LoadFromFile();
            Debug.Log("Data Loaded");
        }

        if (GUILayout.Button("Show Data"))
        {
            Debug.Log(component.ReportCurrentData());
        }
    }
}