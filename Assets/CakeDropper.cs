using UnityEngine;

public class CakeDropper : MonoBehaviour
{
    public Transform holdPoint;         // Where cake_chocolate is held
    public Transform cakeDropPoint;     // Where cake_chocolate should drop

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Mage collided with: " + other.name + " | Tag: " + other.tag);

        if (other.CompareTag("DropZone"))
        {
            Debug.Log("Mage entered the DropZone");

            if (holdPoint.childCount > 0)
            {
                // Get the held item (assume cake_chocolate)
                Transform heldItem = holdPoint.GetChild(0);

                // Unparent it
                heldItem.SetParent(null);

                // Move to cakeDropPoint
                heldItem.position = cakeDropPoint.position;

                // Reactivate physics if needed
                Rigidbody rb = heldItem.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.useGravity = true;
                }

                Debug.Log("Cake dropped at cakeDropPoint");
            }
            else
            {
                Debug.Log("Mage entered DropZone but is not holding cake");
            }
        }
    }
}