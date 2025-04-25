using UnityEngine;

public class CroissantDropper : MonoBehaviour
{
    public Transform holdPoint;            // Where the croissant is held
    public Transform croissantDropPoint;   // Where the croissant should be moved to

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Mage collided with: " + other.name + " | Tag: " + other.tag);

        if (other.CompareTag("DropZone"))
        {
            Debug.Log("Mage entered the DropZone");

            if (holdPoint.childCount > 0)
            {
                // Get the held croissant
                Transform croissant = holdPoint.GetChild(0);

                // Unparent it
                croissant.SetParent(null);

                // Move to croissantDropPoint (NOT where the trigger is)
                croissant.position = croissantDropPoint.position;

                // Enable physics if it has a Rigidbody
                Rigidbody rb = croissant.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.useGravity = true;
                }

                Debug.Log("Croissant dropped at croissantDropPoint");
            }
            else
            {
                Debug.Log("Mage entered DropZone but is not holding a croissant");
            }
        }
    }
}
