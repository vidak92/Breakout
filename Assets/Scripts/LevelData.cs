using UnityEngine;
using UnityEditor;

[System.Serializable]
public enum BrickType
{
    Empty,
    Regular
}

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public const int MaxRows = 8;
    public const int MaxCols = 8;

    [SerializeField, HideInInspector] BrickType[] gridData;


    public bool DataInitialized { get { return gridData != null; } }

    public int Rows { get { return gridData.Length / MaxCols; } }

    public int Cols { get { return gridData.Length / MaxRows; } }


    public void ResetData()
    {
        gridData = new BrickType[MaxRows * MaxCols];
    }

    public BrickType? GetData(int r, int c)
    {
        if (gridData == null)
        {
            Debug.LogError("Cannot get data, gridData is null!");
            return null;
        }
        if (r < 0 || r >= Rows || c < 0 || c >= Cols)
        {
            Debug.LogError("Cannot get data, grid index is out of bounds!");
            return null;
        }
        return gridData[r + Cols * c];
    }

    public void SetData(int r, int c, BrickType type)
    {
        if (gridData == null)
        {
            Debug.LogError("Cannot get data, gridData is null!");
            return;
        }
        if (r < 0 || r >= Rows || c < 0 || c >= Cols)
        {
            Debug.LogError("Cannot get data, grid index is out of bounds!");
            return;
        }
        gridData[r + Cols * c] = type;
    }
}
