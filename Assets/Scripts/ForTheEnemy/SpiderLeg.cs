using UnityEngine;

public class SpiderLeg : MonoBehaviour
{
    [Header("References")]
    public Transform legRoot;       // The shoulder/origin of the leg
    public Transform restPoint;     // Default foot position relative to legRoot
    public Transform rayPoint;      // Where the raycast fires from
    public LayerMask groundMask;

    [Header("Step Settings")]
    public float stepDistance = 0.75f;
    public float stepHeight = 0.25f;
    public float moveSpeed = 8f;

    private Vector3 currentFootPos;
    private Vector3 lastFootPos;
    private bool isStepping = false;

    void Start()
    {
        currentFootPos = transform.position;
        lastFootPos = currentFootPos;
    }

    void Update()
    {
        // Raycast to find ground
        if (Physics.Raycast(rayPoint.position, Vector3.down, out RaycastHit hit, 5f, groundMask))
        {
            Vector3 desiredPos = hit.point;

            // Check if we need to step
            if (!isStepping && Vector3.Distance(desiredPos, lastFootPos) > stepDistance)
            {
                StartCoroutine(Step(desiredPos));
            }
        }

        // Smoothly move target toward currentFootPos
        transform.position = Vector3.Lerp(transform.position, currentFootPos, Time.deltaTime * moveSpeed);
    }

    private System.Collections.IEnumerator Step(Vector3 targetPos)
    {
        isStepping = true;

        Vector3 startPos = currentFootPos;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * moveSpeed;

            // Arc motion
            Vector3 footPos = Vector3.Lerp(startPos, targetPos, t);
            footPos.y += Mathf.Sin(t * Mathf.PI) * stepHeight;

            currentFootPos = footPos;
            yield return null;
        }

        lastFootPos = currentFootPos;
        isStepping = false;
    }
}