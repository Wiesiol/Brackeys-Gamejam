using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    [SerializeField] private RectTransform crosshairUI;
    [SerializeField] private RectTransform canvasRect;
    private Camera mainCamera;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        //crosshairUI = transform as RectTransform;
        //canvasRect = transform.parent.GetComponent<RectTransform>();
    }

    public void SetCrosshairPosition(Vector3 position)
    {
        Vector3 targetPosition = position/* tu wprowadŸ pozycjê, w której chcesz umieœciæ crosshair */;
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(targetPosition);
        crosshairUI.position = screenPosition;
        //Debug.Log("Set");

        //Vector2 ViewportPosition = mainCamera.WorldToViewportPoint(position);
        //Vector2 WorldObject_ScreenPosition = new Vector2(
        //((ViewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)),
        //((ViewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));

        //crosshairUI.anchoredPosition = WorldObject_ScreenPosition;
    }

    public void ShowCrosshair()
    {
        crosshairUI.gameObject.SetActive(true);
    }

    public void HideCrosshair()
    {
        crosshairUI.gameObject.SetActive(false);
    }
}
