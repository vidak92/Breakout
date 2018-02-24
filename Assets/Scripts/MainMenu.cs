using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] IntVar currentLevelIndex;
    [SerializeField] IntVar startingLevelIndex;
    [SerializeField] IntVar currentLivesCount;
    [SerializeField] IntVar startingLivesCount;

    public void StartGame()
    {
        currentLevelIndex.value = startingLevelIndex.value;
        currentLivesCount.value = startingLivesCount.value;
        SceneManager.LoadScene(SceneNames.Game);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }
}
