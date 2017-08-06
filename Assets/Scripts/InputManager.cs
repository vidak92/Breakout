using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
