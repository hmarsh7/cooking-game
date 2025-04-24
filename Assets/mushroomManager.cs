using UnityEngine;

public class MushroomManager : MonoBehaviour
{
    public GameObject mushroomPrefab;
    public Transform spawnPoint;
    public Transform waitPoint;

    void Start()
    {
        SpawnAndMoveMushroom();
    }

    void SpawnAndMoveMushroom()
    {
        // Spawn the mushroom at the spawn point
        GameObject mushroom = Instantiate(mushroomPrefab, spawnPoint.position, Quaternion.identity);

        // Optional: Rotate it 90 degrees left
        mushroom.transform.Rotate(0f, -90f, 0f);

        // Add and configure the movement script
        MushroomMovement movement = mushroom.AddComponent<MushroomMovement>();
        movement.waitPoint = waitPoint.position;
        movement.SetSpawnPoint(spawnPoint.position); // Tell it where to return on click
    }
}