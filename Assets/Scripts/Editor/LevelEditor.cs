using UnityEngine;
using UnityEditor;

public class LevelEditor : EditorWindow
{
    [MenuItem("Window/Level Editor")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(LevelEditor));
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("level editor");
    }
}
