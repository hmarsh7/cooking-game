using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;          // Movement speed
    public float rotationSpeed = 10f;     // Rotation speed for smooth turning

    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Get camera directions
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Ignore vertical tilt
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Combine input with camera direction
        Vector3 movement = cameraForward * moveVertical + cameraRight * moveHorizontal;

        if (movement.magnitude > 0.1f)
        {
            // Move character
            controller.Move(movement.normalized * moveSpeed * Time.deltaTime);

            // Rotate to face movement direction
            Quaternion toRotation = Quaternion.LookRotation(movement.normalized, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            // Play walking animation
            animator.SetFloat("Speed", movement.magnitude);
        }
        else
        {
            // Idle animation
            animator.SetFloat("Speed", 0);
        }
    }
}
