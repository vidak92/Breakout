using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelData))]
public class LevelDataEditor : Editor
{
    GUIStyle styleEmpty;
    GUIStyle styleRegular;
    GUIStyle styleUnbreakable;
    bool stylesInitialized;

    void OnEnable()
    {
        stylesInitialized = false;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (!stylesInitialized)
        {
            styleEmpty = new GUIStyle(GUI.skin.button);
            styleEmpty.normal.textColor = Color.gray;

            styleRegular = new GUIStyle(GUI.skin.button);
            styleRegular.normal.textColor = Color.blue;
            styleRegular.fontStyle = FontStyle.Bold;

            styleUnbreakable = new GUIStyle(GUI.skin.button);
            styleUnbreakable.normal.textColor = Color.red;
            styleUnbreakable.fontStyle = FontStyle.Bold;

            stylesInitialized = true;
        }

        LevelData levelData = target as LevelData;

        if (!levelData.DataInitialized)
        {
            levelData.ResetData();
            SaveAsset();
        }

        EditorGUILayout.LabelField("Rows: " + levelData.Rows + "\tCols: " + levelData.Cols);
        EditorGUILayout.Separator();
        if (GUILayout.Button("Reset Data"))
        {
            levelData.ResetData();
            SaveAsset();
        }
        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("Cells:");
        for (int i = 0; i < levelData.Rows; i++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < levelData.Cols; j++)
            {
                BrickType? type = levelData.GetData(i, j);
                string typeString = "";
                GUIStyle typeStyle = null;
                if (type.HasValue)
                {
                    typeString = GetTypeString(type.Value);
                    typeStyle = GetTypeStyle(type.Value);
                }
                if (GUILayout.Button(typeString, typeStyle))
                {
                    BrickType newType = GetNextType(type.Value);
                    levelData.SetData(i, j, newType);
                    SaveAsset();
                }
            }
            EditorGUILayout.EndHorizontal();
        }
    }

    string GetTypeString(BrickType type)
    {
        switch (type)
        {
            case BrickType.Empty:
                return "E";
            case BrickType.Regular:
                return "R";
            case BrickType.Unbreakable:
                return "U";
            default:
                return "";
        }
    }

    GUIStyle GetTypeStyle(BrickType type)
    {
        switch (type)
        {
            case BrickType.Empty:
                return styleEmpty;
            case BrickType.Regular:
                return styleRegular;
            case BrickType.Unbreakable:
                return styleUnbreakable;
            default:
                return null;
        }
    }

    BrickType GetNextType(BrickType type)
    {
        switch (type)
        {
            case BrickType.Empty:
                return BrickType.Regular;
            case BrickType.Regular:
                return BrickType.Unbreakable;
            case BrickType.Unbreakable:
                return BrickType.Empty;
            default:
                return BrickType.Empty;
        }
    }

    void SaveAsset()
    {
        EditorUtility.SetDirty(target);
        AssetDatabase.SaveAssets();
    }
}
