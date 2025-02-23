using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 30f; // Degrees per second

    [Header("Bobbing Settings")]
    public float bobbingAmplitude = 0.2f; // Height of bobbing movement
    public float bobbingFrequency = 1f;   // Speed of bobbing movement

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position to base the bobbing movement on
        initialPosition = transform.position;
    }

    void Update()
    {
        // Rotate the coin around its Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Calculate new Y position for bobbing effect using a sine wave
        float newY = initialPosition.y + Mathf.Sin(Time.time * bobbingFrequency) * bobbingAmplitude;
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}
