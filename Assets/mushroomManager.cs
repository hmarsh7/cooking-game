using UnityEngine;

public class MushroomManager : MonoBehaviour
{
    public GameObject mushroomPrefab;
    public Transform spawnPoint;
    public Transform waitPoint;

    bool mushroomSpawned = false; // Track if we've spawned the mushroom already

    void Update()
    {
        // Wait until player clicks Start and game has begun
        if (!StartGameManager.gameStarted)
            return;

        // Once the game has started, spawn the mushroom ONCE
        if (!mushroomSpawned)
        {
            SpawnAndMoveMushroom();
            mushroomSpawned = true;
        }
    }

    void SpawnAndMoveMushroom()
    {
        // Spawn the mushroom at the spawn point
        GameObject mushroom = Instantiate(mushroomPrefab, spawnPoint.position, Quaternion.identity);

        // Rotate it to face the wait point (XZ only — keeps upright)
        Vector3 lookAtPosition = new Vector3(waitPoint.position.x, mushroom.transform.position.y, waitPoint.position.z);
        mushroom.transform.LookAt(lookAtPosition);

        // Add and configure the movement script
        MushroomMovement movement = mushroom.AddComponent<MushroomMovement>();
        movement.waitPoint = waitPoint.position;
        movement.SetSpawnPoint(spawnPoint.position);

        Debug.Log("Mushroom spawned and rotated toward wait point.");
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