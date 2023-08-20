using UnityEngine;

public class ForwardPoint
{
    private Vector3 pointInFront;
    private Transform transform;

    public ForwardPoint(Transform transform)
    {
        this.transform = transform;
    }

    public Vector3 GetPoint(Vector3 offset)
    {
        pointInFront = transform.position + (transform.forward * offset.z) + (transform.right * offset.x) + (transform.up * offset.y);
        return pointInFront;
    }



    public void DrawGizmos(float radius)
    {
        Gizmos.DrawWireSphere(pointInFront, radius);
    }
}
