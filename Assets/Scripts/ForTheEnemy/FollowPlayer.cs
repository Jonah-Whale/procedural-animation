using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotateSpeed = 5f;
    public Vector3 offset = Vector3.zero;
    public float zRotationOffset = 45f;

    private Transform player;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;
    }

    void Update()
    {
        if (player == null) return;

        // Movement
        Vector3 targetPos = player.position + offset;
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            moveSpeed * Time.deltaTime
        );

        // Direction to player (Y only)
        Vector3 dir = player.position - transform.position;
        dir.y = 0f;

        if (dir.sqrMagnitude > 0.001f)
        {
            // Base yaw
            float yaw = Quaternion.LookRotation(dir).eulerAngles.y;

            // Build final rotation with Z offset
            Quaternion finalRot = Quaternion.Euler(0f, yaw, zRotationOffset);

            // Smooth rotation
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                finalRot,
                rotateSpeed * Time.deltaTime
            );
        }
    }
}