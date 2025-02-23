using UnityEngine;

public class JumpHandler : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 7f; // Adjust this value to control jump height

    [Header("Ground Check Settings")]
    public Transform groundCheck; // A child transform placed at the bottom of your capsule
    public float groundDistance = 0.2f; // Radius of the sphere used for checking if grounded
    public LayerMask groundMask; // Layer(s) considered as ground

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the capsule is grounded using a sphere check
        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // When the jump button is pressed and the capsule is on the ground, add an upward impulse
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
