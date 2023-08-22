using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Laser
{
    private LineRenderer lineRenderer;
    private readonly Transform transform;

    public Laser(LineRenderer lineRenderer)
    {
        this.lineRenderer = lineRenderer;
        this.lineRenderer.positionCount = 2;
        this.transform = lineRenderer.transform;
    }

    public void DrawLaser(Collider collider)
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, collider.transform.position);
        lineRenderer.enabled = true;
    }

    public void HideLaser()
    {
        lineRenderer.enabled = false;
    }
}
