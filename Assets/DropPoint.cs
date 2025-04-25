using UnityEngine;

public class DropPoint : MonoBehaviour
{
    public Transform mageHoldPoint; // Reference to the Mage's hold point
    public MageScoreTracker mageScoreTracker; // Script with the itemsServed variable

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("[DropPoint] Mage entered drop zone.");

            // Check if mage is holding any object
            if (mageHoldPoint.childCount > 0)
            {
                Transform heldItem = mageHoldPoint.GetChild(0);
                Destroy(heldItem.gameObject);

                mageScoreTracker.itemsServed += 1;
                Debug.Log("[DropPoint] Item served. Total: " + mageScoreTracker.itemsServed);
            }
            else
            {
                Debug.Log("[DropPoint] Mage is not holding anything.");
            }
        }
    }
}

