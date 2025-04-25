using UnityEngine;

public class MushroomClearBread : MonoBehaviour
{
    public Transform breadDropPoint;    // The location where bread gets dropped

    void OnMouseDown()
    {
        Debug.Log("Mushroom clicked to walk away, clearing bread drop point");

        // Destroy all children at the breadDropPoint
        if (breadDropPoint != null)
        {
            foreach (Transform child in breadDropPoint)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
