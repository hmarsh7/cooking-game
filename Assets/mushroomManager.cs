using UnityEngine;
using System.Collections; // <-- Needed for IEnumerator

public class MushroomManager : MonoBehaviour
{
    public GameObject mushroomPrefab;
    public Transform spawnPoint;
    public Transform waitPoint;

    private bool mushroomSpawned = false; // Track if we've spawned the mushroom already
    private GameObject currentMushroom; // Track current mushroom

    void Update()
    {
        if (!StartGameManager.gameStarted)
            return;

        if (!mushroomSpawned)
        {
            SpawnAndMoveMushroom();
            mushroomSpawned = true;
        }
    }

    void SpawnAndMoveMushroom()
    {
        currentMushroom = Instantiate(mushroomPrefab, spawnPoint.position, Quaternion.identity);

        Vector3 lookAtPosition = new Vector3(waitPoint.position.x, spawnPoint.position.y, waitPoint.position.z);
        currentMushroom.transform.LookAt(lookAtPosition);

        MushroomMovement movement = currentMushroom.AddComponent<MushroomMovement>();
        movement.waitPoint = waitPoint.position;
        movement.SetSpawnPoint(spawnPoint.position);
        movement.manager = this; // <-- Tell the mushroom who the manager is

        Debug.Log("Mushroom spawned and rotated toward wait point.");
    }

    public void MushroomFinishedReturn()
    {
        Debug.Log("Mushroom finished return to spawn. Starting respawn timer...");
        Destroy(currentMushroom);

        StartCoroutine(RespawnAfterDelay(5f)); // Wait 5 seconds then respawn
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        mushroomSpawned = false; // Allow respawning
        Debug.Log("Respawning mushroom after delay.");
    }
}





// using UnityEngine;

// public class MushroomManager : MonoBehaviour
// {
//     public GameObject mushroomPrefab;
//     public Transform spawnPoint;
//     public Transform waitPoint;

//     void Start()
//     {
//         if (StartGameManager.gameStarted)
//         {
//             SpawnAndMoveMushroom();
//         }
//     }

//     void Update()
//     {
//         if (StartGameManager.gameStarted && !mushroomSpawned)
//         {
//             SpawnAndMoveMushroom();
//             mushroomSpawned = true;
//         }
//     }

//     bool mushroomSpawned = false; // Track if we've spawned the mushroom already

//     void SpawnAndMoveMushroom()
//     {
//         // Spawn the mushroom at the spawn point
//         GameObject mushroom = Instantiate(mushroomPrefab, spawnPoint.position, Quaternion.identity);

//         // Rotate it to face the wait point (XZ only — keeps upright)
//         Vector3 lookAtPosition = new Vector3(waitPoint.position.x, mushroom.transform.position.y, waitPoint.position.z);
//         mushroom.transform.LookAt(lookAtPosition);

//         // Add and configure the movement script
//         MushroomMovement movement = mushroom.AddComponent<MushroomMovement>();
//         movement.waitPoint = waitPoint.position;
//         movement.SetSpawnPoint(spawnPoint.position);

//         Debug.Log("Mushroom spawned and rotated toward wait point.");
//     }
// }