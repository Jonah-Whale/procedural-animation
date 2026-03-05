using UnityEngine;

public class LegRootFollower : MonoBehaviour
{
    [Header("Assign the ACTUAL body transform here")]
    public Transform body;

    private Vector3 localPos;
    private Quaternion localRot;

    void Start()
    {
        // Capture the original offset relative to the body
        localPos = body.InverseTransformPoint(transform.position);
        localRot = Quaternion.Inverse(body.rotation) * transform.rotation;
    }

    void LateUpdate()
    {
        // Follow the body's position
        transform.position = body.TransformPoint(localPos);

        // Follow the body's rotation
        transform.rotation = body.rotation * localRot;
    }
}