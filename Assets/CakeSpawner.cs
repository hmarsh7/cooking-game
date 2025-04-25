using UnityEngine;

public class CakeSpawner : MonoBehaviour
{
    public GameObject cakePrefab;
    public Transform holdPoint;

    void OnMouseDown()
    {
        if (cakePrefab != null && holdPoint != null)
        {
            // Spawn croissant at hold point
            GameObject heldCake = Instantiate(cakePrefab, holdPoint.position, holdPoint.rotation);

            // Parent it to the hold point so it follows the player
            heldCake.transform.SetParent(holdPoint);

            Debug.Log("Cake picked up!");
        }
    }
}


