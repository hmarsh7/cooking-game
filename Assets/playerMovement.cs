using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float rotationSpeed = 10f; // Rotation speed for smooth turning

    private CharacterController controller;
    private Animator animator;  // Reference to the Animator component

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        // Get input for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Check if there's any movement  this is so hard
        if (movement.magnitude > 0.1f)
        {
            // Move the character
            controller.Move(movement.normalized * moveSpeed * Time.deltaTime);

            // Calculate the target rotation based on movement direction
            Quaternion toRotation = Quaternion.LookRotation(movement.normalized, Vector3.up);

            // Smoothly rotate the character to face the movement direction
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            // Set the "Speed" parameter in the Animator to indicate movement
            animator.SetFloat("Speed", movement.magnitude);  // This will trigger the walking animation
        }
        else
        {
            // If no movement, set Speed to 0, which will trigger the idle animation
            animator.SetFloat("Speed", 0);
        }
    }
}
