using UnityEngine;
using UnityEditor;

public enum BrickType
{
    Empty,
    Regular
}

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public const int Rows = 8;
    public const int Cols = 8;

    BrickType[,] gridData;

    readonly BrickType[,] level1Data = new BrickType[Rows, Cols]
    {
        { BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty },
        { BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular },
        { BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular },
        { BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular },
        { BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular, BrickType.Regular },
        { BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty },
        { BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty },
        { BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty, BrickType.Empty }
    };

    void OnEnable()
    {
        gridData = level1Data;
    }

    public BrickType? GetData(int r, int c)
    {
        if (gridData == null)
        {
            Debug.LogError("Cannot get data, gridData is null!");
            return null;
        }
        if (r < 0 || r >= gridData.GetLength(0) || c < 0 || c >= gridData.GetLength(1))
        {
            Debug.LogError("Cannot get data, grid index is out of bounds!");
            return null;
        }
        return gridData[r, c];
    }
}
