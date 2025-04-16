using UnityEngine;

public class PickUpAndHold : MonoBehaviour
{
    public GameObject pickupItem;    //  Drag your prefab here in the Inspector
    public Transform holdPoint;      // Drag your HoldPoint empty GameObject here
    public float pickupRange = 2f;   // Range to pick up items

    private void Update()
    {
        // Cast a ray forward from the player's position to detect if we're close to a pickup item
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("PickupItem"))
            {
                // Spawn a copy of the item at the hold point
                GameObject heldItem = Instantiate(pickupItem, holdPoint.position, holdPoint.rotation);

                // Attach the held item to the player so it moves with them
                heldItem.transform.SetParent(holdPoint);

                // Optionally, you can scale it to ensure it's the correct size
                heldItem.transform.localScale = Vector3.one *8f;

                // Destroy the original pickup object from the world
               // Destroy(hit.collider.gameObject);
            }
        }
    }
}