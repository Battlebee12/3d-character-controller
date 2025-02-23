using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private InputManager inputManager;
    public Transform cameraTransform; 

    void Start()
    {
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
       if (inputManager.MoveInput.magnitude > 0.1f)
        {
            // Get camera directions
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            // Ignore the Y component to keep movement on a flat plane
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();

            // Convert input into world space movement
            Vector3 moveDirection = (cameraForward * inputManager.MoveInput.z + cameraRight * inputManager.MoveInput.x).normalized;

            // Move player
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

            // Rotate player towards movement direction
            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }
        }
    }
}