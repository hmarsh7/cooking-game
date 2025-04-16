using UnityEngine;

public class TriggerUIOnContact : MonoBehaviour
{
    public GameObject uiElement; // Assign your RawImage or the UI parent object here

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiElement.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiElement.SetActive(false);
        }
    }
}
