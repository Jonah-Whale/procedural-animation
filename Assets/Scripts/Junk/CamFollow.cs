using UnityEngine;

public class CameraFollowX : MonoBehaviour
{
    public Transform target;     // Spider root
    public float followSpeed = 5f;

    private float fixedY;
    private float fixedZ;

    void Start()
    {
        // Lock the camera's starting Y and Z
        fixedY = transform.position.y;
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        // Only follow X
        pos.x = Mathf.Lerp(pos.x, target.position.x, Time.deltaTime * followSpeed);

        // Keep Y and Z fixed
        pos.y = fixedY;
        pos.z = fixedZ;

        transform.position = pos;
    }
}