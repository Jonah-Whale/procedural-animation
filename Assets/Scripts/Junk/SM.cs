using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float turnSpeed = 90f;

    void Update()
    {
        // Move forward
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        // Turn with A/D keys
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turn * turnSpeed * Time.deltaTime);
    }
}