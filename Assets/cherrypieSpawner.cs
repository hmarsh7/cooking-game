using UnityEngine;

public class cherrypieSpawner : MonoBehaviour
{

    public GameObject cherrypiePrefab;
    public Transform holdPoint;

    void OnMouseDown()
    {
        if (cherrypiePrefab != null && holdPoint != null)
        {
            // Spawn croissant at hold point
            GameObject heldCherrypie = Instantiate(cherrypiePrefab, holdPoint.position, holdPoint.rotation);

            // Parent it to the hold point so it follows the player
            heldCherrypie.transform.SetParent(holdPoint);

            Debug.Log("Cherrypie picked up!");
        }
    }
}