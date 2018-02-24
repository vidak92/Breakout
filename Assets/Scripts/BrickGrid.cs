using UnityEngine;

public class BrickGrid : MonoBehaviour
{
    float startX = -11.2f, startY = 8f;

    [SerializeField] GameObject brickPrefab;
    [SerializeField] float brickGap = 0.2f;

    GameObject[,] grid;

    Vector3 BrickScale { get { return brickPrefab.transform.localScale; } }

    void Awake()
    {
        grid = new GameObject[LevelData.MaxRows, LevelData.MaxCols];
        startX = (-LevelData.MaxCols * BrickScale.x - (LevelData.MaxRows - 1) * brickGap + BrickScale.x) / 2f;
        for (int i = 0; i < LevelData.MaxRows; i++)
        {
            for (int j = 0; j < LevelData.MaxCols; j++)
            {
                GameObject brick = Instantiate(brickPrefab) as GameObject;
                float x = startX + j * (BrickScale.x + brickGap);
                float y = startY - i * (BrickScale.y + brickGap);
                brick.transform.parent = transform;
                brick.transform.localPosition = new Vector3(x, y, 0f);
                brick.name = "Brick" + i + j;
                grid[i, j] = brick;
            }
        }


    }

    public void ApplyLevelData(LevelData levelData)
    {
        for (int i = 0; i < levelData.Rows; i++)
        {
            for (int j = 0; j < levelData.Cols; j++)
            {
                BrickType? brickType = levelData.GetData(i, j);
                if (brickType.HasValue && brickType.Value == BrickType.Regular)
                {
                    grid[i, j].SetActive(true);
                }
                else
                {
                    grid[i, j].SetActive(false);
                }
            }
        }
    }
}
