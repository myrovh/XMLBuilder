using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildComponent))]
class BuildComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BuildComponent component = (BuildComponent) target;

        DrawDefaultInspector();

        if (GUILayout.Button("Test Save"))
        {
            component.SaveCurrentData();
            Debug.Log("Data Saved");
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