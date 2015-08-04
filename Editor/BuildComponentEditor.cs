using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildComponent))]
class BuildComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Build Now"))
            Debug.Log("It's alive: " + target.name);
    }
}