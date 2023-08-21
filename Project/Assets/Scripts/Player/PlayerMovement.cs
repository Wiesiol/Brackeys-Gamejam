using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float turnSmoothTime;
    [SerializeField] private float ascendSpeed;
    private Vector2 movementDirection;
    private Vector2 movementInput;
    private float ascendInput;
    private Vector3 forceDirection;
    private float turnSmoothVelocity;

    private void Start()
    {
        rb.useGravity = false;
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        movementInput = InputManager.Input.Gameplay.Movement.ReadValue<Vector2>();
        ascendInput = InputManager.Input.Gameplay.AscendDescend.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        //forceDirection += movementInput.x * StaticCameraUtils.GetCameraRight() * speed;
        //forceDirection += movementInput.y * StaticCameraUtils.GetCameraForward() * speed;

        //Debug.Log(forceDirection);

        ////rb.AddForce(forceDirection, ForceMode.Impulse);


        //rb.velocity = Vector3.MoveTowards(rb.velocity, forceDirection, speed) * Time.fixedDeltaTime;
        //var horizontalVelocity = rb.velocity;
        //horizontalVelocity.y = 0;
        //if (rb.velocity.sqrMagnitude > maxVelocity * maxVelocity)
        //{
        //    rb.velocity = horizontalVelocity.normalized * maxVelocity + Vector3.up * rb.velocity.y;
        //}

        //var velocity = rb.velocity;
        //velocity.y = Mathf.MoveTowards(velocity.y, ascendInput * speed, speed);

        var direction = new Vector3(movementInput.x, 0f, movementInput.y).normalized;

        Vector3 movedir = Vector3.zero;
        if (direction.magnitude >= 0.1f)
        {
            var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            movedir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }

        movedir.y = ascendInput * ascendSpeed;

        if (direction != Vector3.zero)
            rb.MovePosition(transform.position + movedir * speed * Time.fixedDeltaTime);

        //var velocity = rb.velocity;
        //velocity.y = Mathf.MoveTowards(velocity.y, ascendInput * speed, speed);

        //rb.velocity = velocity;
        ////rb.MovePosition(transform.position + velocity);

        LookForward();
    }

    private void LookForward()
    {
        var direction = rb.velocity;
        direction.y = 0;

        if (movementInput.sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
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