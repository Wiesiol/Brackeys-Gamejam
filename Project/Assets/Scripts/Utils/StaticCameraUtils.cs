using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public static class StaticCameraUtils
{
    private static Transform cameraTransform;
    private static CinemachineFreeLook playerCam;

    static StaticCameraUtils()
    {
        cameraTransform = Camera.main.transform;
    }

    public static Vector3 GetCameraForward()
    {
        var forward = cameraTransform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    public static Vector3 GetCameraRight()
    {
        var right = cameraTransform.right;
        right.y = 0;
        return right.normalized;
    }

    public static void SetPlayerCameraActive(bool status)
    {
        if(playerCam == null)
        {
            playerCam = GameObject.Find("TPPCamera").GetComponent<CinemachineFreeLook>();
        }

        playerCam.enabled = status;
    }
}