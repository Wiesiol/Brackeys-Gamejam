using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float turnSmoothTime;
    [SerializeField] private float ascendSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private AnimationCurve speedCurve;
    [SerializeField] private AnimationCurve speedDownCurve;

    private Vector2 movementInput;
    private float ascendInput;
    private float turnSmoothVelocity;
    private float accelerationTime;
    private Vector3 prevMoveDir;

    private void Start()
    {
        rb.useGravity = false;

        //TODO: zmieniæ to gówno
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

        if ((movementInput.x != 0 || movementInput.y != 0 || ascendInput != 0)&& accelerationTime < 1)
        {
            accelerationTime += Time.fixedDeltaTime;
        }
        else if (accelerationTime > 0f)
        {
            accelerationTime -= Time.fixedDeltaTime;
            prevMoveDir *= speedDownCurve.Evaluate(accelerationTime);
            rb.MovePosition(transform.position + prevMoveDir * speed * Time.fixedDeltaTime);
            return;
        }

        if (movedir != Vector3.zero)
        {
            movedir *= speedCurve.Evaluate(accelerationTime);
            prevMoveDir = movedir;
            rb.MovePosition(transform.position + movedir * speed * Time.fixedDeltaTime);
        }


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