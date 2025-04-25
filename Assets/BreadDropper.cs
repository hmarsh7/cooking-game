using UnityEngine;

public class BreadDropper : MonoBehaviour
{
    public Transform holdPoint;          // Where bread is held
    public Transform breadDropPoint;     // Where bread should drop

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Mage collided with: " + other.name + " | Tag: " + other.tag);

        if (other.CompareTag("DropZone"))
        {
            Debug.Log("Mage entered the DropZone");

            if (holdPoint.childCount > 0)
            {
                // Get the held bread
                Transform heldItem = holdPoint.GetChild(0);

                // Unparent from holdPoint first
                heldItem.SetParent(null);

                // Move bread to breadDropPoint's position
                heldItem.position = breadDropPoint.position;

                // Re-parent it under breadDropPoint
                heldItem.SetParent(breadDropPoint);

                // Reactivate physics if needed
                Rigidbody rb = heldItem.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.useGravity = true;
                }

                Debug.Log("Bread dropped at breadDropPoint and parented under it");
            }
            else
            {
                Debug.Log("Mage entered DropZone but is not holding bread");
            }
        }
    }
}
