using UnityEngine;

public class CroissantSpawner : MonoBehaviour
{
    public GameObject croissantPrefab;
    public Transform holdPoint;

    void OnMouseDown()
    {
        if (croissantPrefab != null && holdPoint != null)
        {
            // Spawn croissant at hold point
            GameObject heldCroissant = Instantiate(croissantPrefab, holdPoint.position, holdPoint.rotation);

            // Parent it to the hold point so it follows the player
            heldCroissant.transform.SetParent(holdPoint);

            Debug.Log("Croissant picked up!");
        }
    }
}