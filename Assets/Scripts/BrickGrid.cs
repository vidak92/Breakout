using UnityEngine;

public class BrickGrid : MonoBehaviour
{
    public const int MaxRows = 10, MaxCols = 8;

    readonly float startX = -11.2f, startY = 8f;

    [SerializeField] GameObject brickPrefab;
    [SerializeField] float brickGap = 0.2f;
    [SerializeField] int levelIndex = 0;

    Vector3 BrickScale { get { return brickPrefab.transform.localScale; } }

    void Awake()
    {
//        float startX = (-maxCols * BrickScale.x - (maxCols - 1) * brickGap + BrickScale.x) / 2f;
        char[,] currentLevel = LevelData.Levels[levelIndex];
        for (int i = 0; i < MaxRows; i++)
        {
            for (int j = 0; j < MaxCols; j++)
            {
                if (currentLevel[i, j] == 'B')
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
