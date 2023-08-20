using UnityEngine;

public class ForwardPoint : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    private Vector3 pointInFront;

    private void Update()
    {
        pointInFront = transform.position + (transform.forward * offset.z) + (transform.right * offset.x) + transform.up * offset.y;
        Debug.Log(transform.forward);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pointInFront, 2);
    }
}
