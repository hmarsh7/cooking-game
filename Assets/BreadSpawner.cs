using UnityEngine;

public class BreadSpawner : MonoBehaviour
{
    public GameObject breadPrefab;
    public Transform holdPoint;

    void OnMouseDown()
    {
        if (breadPrefab != null && holdPoint != null)
        {
            // Spawn croissant at hold point
            GameObject heldBread = Instantiate(breadPrefab, holdPoint.position, holdPoint.rotation);

            // Parent it to the hold point so it follows the player
            heldBread.transform.SetParent(holdPoint);

            Debug.Log("bread picked up!");
        }
    }
}


