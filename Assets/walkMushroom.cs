using UnityEngine;

public class MushroomMovement : MonoBehaviour
{
    public Vector3 waitPoint;
    public Vector3 spawnPoint;  // renamed from exitPoint
    public float moveSpeed = 2f;

    private bool hasArrivedAtWait = false;
    private bool movingBackToSpawn = false;

    void Update()
    {
        if (!hasArrivedAtWait)
        {
            // Move toward wait point
            transform.position = Vector3.MoveTowards(transform.position, waitPoint, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, waitPoint) < 0.1f)
            {
                hasArrivedAtWait = true;
                Debug.Log("Mushroom arrived at wait point");
            }
        }
        else if (movingBackToSpawn)
        {
            // Move back to spawn point
            transform.position = Vector3.MoveTowards(transform.position, spawnPoint, moveSpeed * Time.deltaTime);
            Debug.Log("Mushroom moving back to spawn point");
        }
    }

    public void SetSpawnPoint(Vector3 spawnTarget)
    {
        spawnPoint = spawnTarget;
        Debug.Log("Spawn point set to: " + spawnPoint);
    }

    void OnMouseDown()
    {
        if (hasArrivedAtWait)
        {
            movingBackToSpawn = true;
            Debug.Log("Mushroom clicked — moving back to spawn point");
        }
        else
        {
            Debug.Log("Clicked before reaching wait point");
        }
    }
}