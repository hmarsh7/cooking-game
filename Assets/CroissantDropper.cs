using UnityEngine;

public class CroissantDropper : MonoBehaviour
{
    public Transform holdPoint;      // Where the croissant is held
    public Transform dropPoint;      // Where it should be dropped

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DropZone"))
        {
            Debug.Log("Mage entered the DropZone!");

            // Make sure the player is holding something
            if (holdPoint.childCount > 0)
            {
                // Get the croissant
                Transform croissant = holdPoint.GetChild(0);

                // Unparent it
                croissant.SetParent(null);

                // Move it to the drop point
                croissant.position = dropPoint.position;

                // Optional: Enable physics if needed
                Rigidbody rb = croissant.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.useGravity = true;
                }

                Debug.Log("Croissant dropped at the drop point!");
            }
            else
            {
                Debug.Log("Mage entered drop zone but isn't holding a croissant.");
            }
        }
    }
}