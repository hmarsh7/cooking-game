using UnityEngine;

public class MushroomMovement : MonoBehaviour
{
    public Vector3 waitPoint;
    public Vector3 spawnPoint;
    public float moveSpeed = 3.5f;

    private enum MushroomState { MovingToWait, Waiting, ReturningToSpawn }
    private MushroomState currentState = MushroomState.MovingToWait;

    void Update()
    {
        switch (currentState)
        {
            case MushroomState.MovingToWait:
                MoveToPoint(waitPoint, MushroomState.Waiting, "Mushroom arrived at wait point.");
                break;

            case MushroomState.ReturningToSpawn:
                MoveToPoint(spawnPoint, MushroomState.Waiting, "Mushroom returned to spawn point.");
                break;

            case MushroomState.Waiting:
                // Do nothing until clicked
                break;
        }
    }

    private void MoveToPoint(Vector3 target, MushroomState nextState, string debugMessage)
    {
        // Only move along XZ (keep current Y)
        Vector3 currentXZ = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 targetXZ = new Vector3(target.x, 0, target.z);
        float flatDistance = Vector3.Distance(currentXZ, targetXZ);

        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(target.x, transform.position.y, target.z),
            moveSpeed * Time.deltaTime
        );

        if (flatDistance <= 0.05f)
        {
            transform.position = new Vector3(target.x, transform.position.y, target.z);
            currentState = nextState;
            Debug.Log(debugMessage);
        }
    }

    public void SetSpawnPoint(Vector3 spawnTarget)
    {
        spawnPoint = spawnTarget;
        Debug.Log("Spawn point set to: " + spawnPoint);
    }

    void OnMouseDown()
    {
        if (currentState == MushroomState.Waiting)
        {
            // Turn to face the spawn point before walking back
            Vector3 lookAtSpawn = new Vector3(spawnPoint.x, transform.position.y, spawnPoint.z);
            transform.LookAt(lookAtSpawn);

            currentState = MushroomState.ReturningToSpawn;
            Debug.Log("Mushroom clicked — turning and returning to spawn point.");
        }
        else
        {
            Debug.Log("Clicked before mushroom was ready.");
        }
    }
}
