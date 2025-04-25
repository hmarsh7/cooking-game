using UnityEngine;

public class CakeSpawner : MonoBehaviour
{
    public GameObject cakePrefab;    // The cake_chocolate prefab to instantiate
    public Transform holdPoint;      // Where the cake will be held

    void OnMouseDown()
    {
        if (cakePrefab != null && holdPoint != null)
        {
            // Instantiate the cake at the hold point's position and rotation
            GameObject heldCake = Instantiate(cakePrefab, holdPoint.position, holdPoint.rotation);

            // Parent the new cake to the hold point
            heldCake.transform.SetParent(holdPoint);

            // Optional: disable physics while being held
            Rigidbody rb = heldCake.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }

            Debug.Log("Cake picked up and attached to hold point");
        }
    }
}
