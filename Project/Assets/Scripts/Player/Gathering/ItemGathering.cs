using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using System;

public class ItemGathering : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float radius;
    [SerializeField] private Transform sphereCenterPoint;
    [SerializeField] private LayerMask ignorePlayer;
    [SerializeField] private LayerMask gatherable;
    [SerializeField] private LineRenderer lineRenderer;
    private Vector3 offsetVector;
    private ForwardPoint sphereCenter;
    private float distanceFromPlayer;
    private Dictionary<Collider, float> distances = new();
    private List<Collider> sortedColliders = new();
    private Laser laser;
    private Collider selectedCollider;

    void Awake()
    {
        laser = new Laser(lineRenderer);
        sphereCenter = new ForwardPoint(sphereCenterPoint);
        distanceFromPlayer = Vector3.Distance(transform.position, sphereCenterPoint.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(sphereCenterPoint.position, radius);
    }

    void Update()
    {
        distances.Clear();

        Collider[] hits = Physics.OverlapSphere(sphereCenterPoint.position, radius, gatherable);

        if (selectedCollider == null || !hits.Contains(selectedCollider))
        {

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
                    ShootAndGather(collider);
                    return;
                }
            }
            PlayerSystems.CrosshairController.HideCrosshair();
            laser.HideLaser();
            SoundManager.Instance.StopLaser();
        }
        else
        {
            ShootAndGather(selectedCollider);
        }
    }

    private void ShootAndGather(Collider collider)
    {
        if (InputManager.Input.Gameplay.Gather.IsPressed())
        {
            SoundManager.Instance.PlayLaser();
            selectedCollider = collider;
            laser.DrawLaser(collider);
            collider.GetComponent<IGatherable>().Gather();
        }
        else
        {
            selectedCollider = null;
            laser.HideLaser();
            SoundManager.Instance.StopLaser();
        }

        PlayerSystems.CrosshairController.SetCrosshairPosition(collider.transform.position);
        PlayerSystems.CrosshairController.ShowCrosshair();
    }
}
