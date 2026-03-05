using UnityEngine;

public class RayPointHeightFollower : MonoBehaviour
{
    public float rayDistance = 5f;
    public float heightOffset = 0.1f;
    public float followSpeed = 20f;
    public LayerMask groundMask;

    void Update()
    {
        if (Physics.Raycast(transform.position + Vector3.up * 1f, Vector3.down, out RaycastHit hit, rayDistance, groundMask))
        {
            Vector3 targetPos = hit.point + Vector3.up * heightOffset;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);
        }
    }
}