using UnityEngine;

public class SpiderBodyController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Move forward/backward
        Vector3 move = transform.forward * v * moveSpeed * Time.deltaTime;
        transform.position += move;

        // Rotate left/right
        transform.Rotate(Vector3.up, h * turnSpeed * Time.deltaTime);
    }
}