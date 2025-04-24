using UnityEngine;

public class MushroomMovement : MonoBehaviour
{
    public Vector3 targetPoint;
    public float moveSpeed = 2f;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
    }
}