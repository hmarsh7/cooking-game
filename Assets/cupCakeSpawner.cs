using UnityEngine;

public class cupCakeSpawner : MonoBehaviour
{

    public GameObject cupcakePrefab;
    public Transform holdPoint;

    void OnMouseDown()
    {
        if (cupcakePrefab != null && holdPoint != null)
        {
            // Spawn croissant at hold point
            GameObject heldCupcake = Instantiate(cupcakePrefab, holdPoint.position, holdPoint.rotation);

            // Parent it to the hold point so it follows the player
            heldCupcake.transform.SetParent(holdPoint);

            Debug.Log("Cupcake picked up!");
        }
    }
}