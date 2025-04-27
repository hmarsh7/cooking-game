

using UnityEngine;

public class quitGameButton : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("[GameExit] Exit button clicked. Quitting game.");
        Application.Quit();
    }
}