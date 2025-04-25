using UnityEngine;

public class BreadSpawner : MonoBehaviour
{
    public GameObject breadPrefab;     // The bread prefab to instantiate
    public Transform holdPoint;        // Where the bread should spawn and be held

    void OnMouseDown()
    {
        if (breadPrefab != null && holdPoint != null)
        {
            // Instantiate the bread at the hold point position and rotation
            GameObject heldBread = Instantiate(breadPrefab, holdPoint.position, holdPoint.rotation);

            // Parent the new bread to the hold point
            heldBread.transform.SetParent(holdPoint);

            // Optional: turn off gravity while held
            Rigidbody rb = heldBread.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }

            Debug.Log("Bread picked up and attached to hold point");
        }
    }
}
