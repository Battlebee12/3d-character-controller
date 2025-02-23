using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Vector3 MoveInput { get; private set; }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float moveY = 0f;
        
        if (Input.GetKey(KeyCode.Space)) moveY = 1f;
        if (Input.GetKey(KeyCode.LeftControl)) moveY = -1f;
        
        MoveInput = new Vector3(moveX, moveY, moveZ).normalized;
    }
}