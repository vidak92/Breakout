using UnityEngine;

public class BrickGrid : MonoBehaviour
{
    readonly float startX = -11.2f, startY = 8f;

    [SerializeField] GameObject brickPrefab;
    [SerializeField] float brickGap = 0.2f;
    [SerializeField] LevelData levelData;

    Vector3 BrickScale { get { return brickPrefab.transform.localScale; } }

    void Awake()
    {
        float startX = (-LevelData.Cols * BrickScale.x - (LevelData.Rows - 1) * brickGap + BrickScale.x) / 2f;
        for (int i = 0; i < LevelData.Rows; i++)
        {
            for (int j = 0; j < LevelData.Cols; j++)
            {
                BrickType? brickType = levelData.GetData(i, j);
                if (brickType.HasValue && brickType.Value == BrickType.Regular)
                {
                    GameObject brick = Instantiate(brickPrefab) as GameObject;
                    float x = startX + j * (BrickScale.x + brickGap);
                    float y = startY - i * (BrickScale.y + brickGap);
                    brick.transform.parent = transform;
                    brick.transform.localPosition = new Vector3(x, y, 0f);
                    brick.name = "Brick" + i + j;
                }
            }
        }
    }
}
