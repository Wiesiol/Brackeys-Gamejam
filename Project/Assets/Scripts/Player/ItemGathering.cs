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
    private Vector3 offsetVector;
    private ForwardPoint sphereCenter;

    void Awake()
    {
        sphereCenter = new ForwardPoint(transform);
    }

    void Start()
    {
        
    }



    private float ClosestItem(Collider collider)
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 cameraDirection = StaticCameraUtils.GetCameraForward();
        Vector3 colliderPosition = collider.transform.position;
        return ((cameraPosition - colliderPosition) - (Vector3.Dot(cameraPosition - colliderPosition, cameraDirection) * cameraDirection)).magnitude;
    }

    void OnGismosDrawSelected()
    {
        sphereCenter.DrawGizmos(radius);
    }

    // Update is called once per frame
    void Update()
    {
        Dictionary<Collider, float> distances = new Dictionary<Collider, float>();
        Collider[] hits = Physics.OverlapSphere(sphereCenter.GetPoint(offset), radius, LayerMask.NameToLayer("Gatherable"));
        foreach (Collider hit in hits) {
            distances.Add(hit, ClosestItem(hit));
        }
        List<Collider> sortedColliders = distances.OrderBy(n => n.Value).Select(n => n.Key).ToList();
        foreach (Collider collider in sortedColliders) {
            Physics.Raycast(transform.position, collider.transform.position, out var raycastHit);
            if (raycastHit.collider == collider) {
                Debug.Log(collider.name);
            }
        }
    }
}
