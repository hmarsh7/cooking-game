using UnityEngine;

public class PickUpAndHold : MonoBehaviour
{
    public GameObject pickupItem;    // Drag your prefab here in the Inspector
    public Transform holdPoint;      // Drag your HoldPoint empty GameObject here
    public Transform tablePoint;     // New: The point where you want to drop the object (on the table)
    public float pickupRange = 2f;   // Range to pick up items
    private GameObject heldItem;     // To store the currently held item

    private void Update()
    {
        // Detect if we are close to a pickup item
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("PickupItem"))
            {
                // Spawn a copy of the item at the hold point and scale it 10 times
                if (heldItem == null)  // Only pick up an item if we aren't already holding one
                {
                    heldItem = Instantiate(pickupItem, holdPoint.position, holdPoint.rotation);
                    heldItem.transform.SetParent(holdPoint);
                    heldItem.transform.localScale = Vector3.one * 10f; // Scale it 10 times bigger
                }
            }
        }

        // Drop the item when the Enter key is pressed
        if (Input.GetKeyDown(KeyCode.Return) && heldItem != null)
        {
            DropItem();
        }
    }

    // Drop the item at the table point
    private void DropItem()
    {
        // Detach the item from the player's hand (hold point)
        heldItem.transform.SetParent(null);

        // Place it at the table point
        heldItem.transform.position = tablePoint.position;

        // Optionally, if you want it to return to its original size, you can set the scale back
        heldItem.transform.localScale = Vector3.one *10f;

        // Clear the reference to the held item
        heldItem = null;
    }
}