using UnityEngine;

public class GameExit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("[GameExit] Escape key pressed. Quitting game.");
            Application.Quit();
        }
    }
}