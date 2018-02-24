using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Lives")]
    [SerializeField] IntVar remainingLives;
    [SerializeField] string livesTextPrefix;

    [Header("Level Data")]
//    [SerializeField] LevelDataRef currentLevel;
    [SerializeField] IntVar currentLevelIndex;
    [SerializeField] LevelData[] levels;

    [Header("UI")]
    [SerializeField] Text titleText;
    [SerializeField] Text livesText;

    [Header("Bricks")]
    [SerializeField] GameObject brickGridRoot;
    [SerializeField] GameObject brickPrefab;
    [SerializeField] float brickGap = 0.4f;

    [Header("Ball")]
    [SerializeField] GameObject ballPrefab;

    float startX = -11.2f, startY = 8f;
    Brick[,] bricks;
    int activeBrickCount;

    Vector3 BrickScale { get { return brickPrefab.transform.localScale; } }

    void OnEnable()
    {
        Ball.BrickDestroyed += OnBrickDestroyed;
        Ball.BallLost += OnBallLost;
    }

    void OnDisable()
    {
        Ball.BrickDestroyed -= OnBrickDestroyed;
        Ball.BallLost -= OnBallLost;
    }

    void Awake()
    {
        bricks = new Brick[LevelData.MaxRows, LevelData.MaxCols];
        startX = (-LevelData.MaxCols * BrickScale.x - (LevelData.MaxRows - 1) * brickGap + BrickScale.x) / 2f;
        for (int i = 0; i < LevelData.MaxRows; i++)
        {
            for (int j = 0; j < LevelData.MaxCols; j++)
            {
                GameObject brickObject = Instantiate(brickPrefab) as GameObject;
                float x = startX + j * (BrickScale.x + brickGap);
                float y = startY - i * (BrickScale.y + brickGap);
                brickObject.transform.parent = brickGridRoot.transform;
                brickObject.transform.localPosition = new Vector3(x, y, 0f);
                brickObject.name = "Brick" + i + j;
                brickObject.SetActive(false);
                bricks[i, j] = brickObject.GetComponent<Brick>();
            }
        }
    }

    void Start()
    {
        LevelData levelData = levels[currentLevelIndex.value];

        titleText.text = levelData.LevelName;
        UpdateLivesText();

        activeBrickCount = 0;
        for (int i = 0; i < levelData.Rows; i++)
        {
            for (int j = 0; j < levelData.Cols; j++)
            {
                BrickType? brickType = levelData.GetData(i, j);
                if (brickType.HasValue)
                {
                    if (brickType.Value == BrickType.Regular)
                    {
                        bricks[i, j].gameObject.SetActive(true);
                        activeBrickCount++;
                    }
                    else if (brickType.Value == BrickType.Unbreakable)
                    {
                        bricks[i, j].gameObject.SetActive(true);
                    }
                    bricks[i, j].Type = brickType.Value;
                }
//                else
//                {
//                    grid[i, j].SetActive(false);
//                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneNames.Game);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneNames.Main);
        }
    }

    void OnBrickDestroyed()
    {
        Debug.Log("brick destroyed");
        activeBrickCount--;
        if (activeBrickCount <= 0)
        {
            currentLevelIndex.value = ++currentLevelIndex.value % levels.Length;
            SceneManager.LoadScene(SceneNames.Game);
        }
    }

    void OnBallLost()
    {
        Debug.Log("ball exit");
        remainingLives.value--;
        UpdateLivesText();
        if (remainingLives.value <= 0)
        {
            SceneManager.LoadScene(SceneNames.Main);
        }
        else
        {
            Instantiate(ballPrefab);
        }
    }

    void UpdateLivesText()
    {
        livesText.text = string.Format("{0}{1}", livesTextPrefix, remainingLives.value);
    }
}
