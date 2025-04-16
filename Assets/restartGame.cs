using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    void Update()
    {
        // If Backspace is pressed, reload the active scene
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}