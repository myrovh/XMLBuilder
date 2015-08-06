using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildComponent))]
class BuildComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BuildComponent component = (BuildComponent) target;

        DrawDefaultInspector();

        if (GUILayout.Button("Create Template"))
        {
            component.UpdateDataFromWorld();
            component.SaveCurrentData();
        }

        if (GUILayout.Button("Load"))
        {
            component.LoadFromFile();
        }

        if (GUILayout.Button("Show Data"))
        {
            Debug.Log(component.ReportCurrentData());
        }

        if (GUILayout.Button("Build"))
        {
            component.RemoveChildrenObjects();
            component.CreateChildrenObjects();
        }
    }
}