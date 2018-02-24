using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelDataRef levelDataRef;
    [SerializeField] BrickGrid brickGrid;
    [SerializeField] Text titleText;

    void Start()
    {
        LevelData levelData = levelDataRef.value;
        titleText.text = levelData.LevelName;
        brickGrid.ApplyLevelData(levelData);
    }
}
