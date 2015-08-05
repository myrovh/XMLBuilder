using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildComponent))]
class BuildComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Test Save"))
        {
            BuildComponent component = (BuildComponent) target;
            component.SaveCurrentData();
            Debug.Log("Data Saved");
        }

    }
}