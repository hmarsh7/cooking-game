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
        GameObject mushroom = Instantiate(mushroomPrefab, spawnPoint.position, Quaternion.identity);
        // Rotate the mushroom 90 degrees to the left (negative Y axis)
        mushroom.transform.Rotate(0f, 90f, 0f);

        MushroomMovement movement = mushroom.AddComponent<MushroomMovement>();
        movement.targetPoint = waitPoint.position;
    }
}