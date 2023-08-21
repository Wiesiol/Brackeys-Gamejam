using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

public class ItemGathering : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float radius;
    [SerializeField] private Transform sphereCenterPoint;
    [SerializeField] private LayerMask ignorePlayer;
    [SerializeField] private LayerMask gatherable;
    private Vector3 offsetVector;
    private ForwardPoint sphereCenter;
    private Dictionary<Collider, float> distances = new();
    private List<Collider> sortedColliders = new();

    void Awake()
    {
        sphereCenter = new ForwardPoint(sphereCenterPoint);
    }

    private float ClosestItem(Collider collider)
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 cameraDirection = StaticCameraUtils.GetCameraForward();
        Vector3 colliderPosition = collider.transform.position;
        return ((cameraPosition - colliderPosition) - (Vector3.Dot(cameraPosition - colliderPosition, cameraDirection) * cameraDirection)).magnitude;
    }

    private void OnDrawGizmosSelected()
    {
        //if (Application.isPlaying)
        //{
        //    sphereCenter.DrawGizmos(radius);
        //}

        Gizmos.DrawWireSphere(sphereCenterPoint.position, radius);
    }

    // Update is called once per frame
    void Update()
    {
        distances.Clear();

        Collider[] hits = Physics.OverlapSphere(/*sphereCenter.GetPoint(offset)*/sphereCenterPoint.position, radius, gatherable);
        //foreach (Collider hit in hits) {
        //    distances.Add(hit, ClosestItem(hit));
        //}

        foreach (var col in hits)
        {
            var pointInScreen = Camera.main.WorldToViewportPoint(col.transform.position);

            if (pointInScreen.x < 0 || 
                pointInScreen.y < 0 || 
                pointInScreen.x > 1 || 
                pointInScreen.y > 1)
            {
                continue;
            }


            var camCenter = new Vector2(0.5f, 0.5f);

            var distance = Vector2.Distance(camCenter, (Vector2)pointInScreen);
            distances.Add(col, distance);
        }
        sortedColliders = distances.OrderBy(n => n.Value).Select(n => n.Key).ToList();

        foreach (Collider collider in sortedColliders)
        {
            Physics.Linecast(transform.position, collider.transform.position, out var raycastHit, ignorePlayer);
            if (raycastHit.collider == collider)
            {
                Debug.Log(collider.name);
                return;
            }
        }
    }
}
