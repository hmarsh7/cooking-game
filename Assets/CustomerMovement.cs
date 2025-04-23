using UnityEngine;
using System.Collections;

public class MushroomCustomer : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 2.0f;
    public Transform entrancePoint;
    public Transform orderPoint;
    public Transform exitPoint;

    [Header("Order Settings")]
    public float minWaitTime = 10.0f;
    public float maxWaitTime = 30.0f;

    private enum CustomerState
    {
        Entering,
        Waiting,
        Leaving,
        Idle
    }

    private CustomerState currentState = CustomerState.Idle;
    private bool hasOrder = false;

    void Start()
    {
        // Start the customer behavior
        StartCoroutine(CustomerBehavior());
    }

    void Update()
    {
        // Handle movement based on current state
        switch (currentState)
        {
            case CustomerState.Entering:
                MoveTowards(orderPoint.position);
                break;

            case CustomerState.Leaving:
                MoveTowards(exitPoint.position);
                break;

            case CustomerState.Waiting:
            case CustomerState.Idle:
                // Do nothing, just wait
                break;
        }
    }

    private void MoveTowards(Vector3 targetPosition)
    {
        // Get the direction to move (only on X and Z axes, keeping Y the same)
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0; // Keep the same height

        // Normalize for consistent speed
        if (direction.magnitude > 0.1f)
        {
            direction.Normalize();

            // Move the customer
            transform.position += direction * walkSpeed * Time.deltaTime;

            // Rotate to face movement direction
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    private bool HasReachedTarget(Vector3 targetPosition, float threshold = 0.5f)
    {
        // Check if we've reached the target (ignoring Y axis)
        Vector3 flatPosition = transform.position;
        Vector3 flatTarget = targetPosition;
        flatPosition.y = 0;
        flatTarget.y = 0;

        return Vector3.Distance(flatPosition, flatTarget) < threshold;
    }

    public void GiveOrder()
    {
        // Call this method when the player gives the mushroom customer their order
        hasOrder = true;
    }

    IEnumerator CustomerBehavior()
    {
        // Set initial position at entrance
        transform.position = entrancePoint.position;

        // Start entering
        currentState = CustomerState.Entering;

        // Wait until we reach the order point
        while (!HasReachedTarget(orderPoint.position))
        {
            yield return null;
        }

        // Now we're waiting for order
        currentState = CustomerState.Waiting;

        // Wait until we get our order or maximum wait time is reached
        float waitTime = Random.Range(minWaitTime, maxWaitTime);
        float timer = 0;

        while (!hasOrder && timer < waitTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        // If timer ran out and we didn't get order, customer leaves angry
        // (you could add additional behavior here)

        // Start leaving
        currentState = CustomerState.Leaving;

        // Wait until we reach the exit
        while (!HasReachedTarget(exitPoint.position))
        {
            yield return null;
        }

        // We've reached the exit, destroy the customer or deactivate for pooling
        gameObject.SetActive(false);
        Destroy(gameObject, 0.1f);
    }
}