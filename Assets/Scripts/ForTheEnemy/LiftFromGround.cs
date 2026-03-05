using UnityEngine;

public class MinHeightHover : MonoBehaviour
{
    [Header("Raycast Settings")]
    public float rayDistance = 5f;          // How far down to check
    public float minHeight = 1f;            // Minimum allowed distance from ground
    public LayerMask groundMask;

    [Header("Movement Settings")]
    public float adjustSpeed = 6f;          // How fast to correct height

    void Update()
    {
        Vector3 origin = transform.position;

        // Debug ray (green = no hit, red = hit)
        Debug.DrawRay(origin, Vector3.down * rayDistance, Color.green);

        if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, rayDistance, groundMask))
        {
            Debug.DrawLine(origin, hit.point, Color.red);

            float currentHeight = hit.distance;

            // Calculate how far off we are from the minimum height
            float heightError = minHeight - currentHeight;

            // If heightError > 0 → too close → move up
            // If heightError < 0 → too far → move down
            Vector3 newPos = transform.position + Vector3.up * heightError;

            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * adjustSpeed);
        }
    }
}