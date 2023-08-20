using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    private Vector2 movementDirection;
    private Vector2 movementInput;
    private Vector3 forceDirection;

    private void Move(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        movementInput = InputManager.Instance.Input.Gameplay.Movement.ReadValue<Vector2>();
        Debug.Log(movementDirection);
    }

    private void FixedUpdate()
    {
        forceDirection += movementInput.x * StaticCameraUtils.GetCameraRight() * speed;
        forceDirection += movementInput.y * StaticCameraUtils.GetCameraForward() * speed;

        rb.AddForce(forceDirection, ForceMode.Impulse);


    }
}

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