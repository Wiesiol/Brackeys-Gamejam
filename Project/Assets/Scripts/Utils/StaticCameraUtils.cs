using UnityEngine;

public static class StaticCameraUtils
{
    private static Transform cameraTransform;

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
}