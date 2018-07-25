﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour {

    public float walkSpeed = 2;
    public float runSpeed = 6;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	

	void Update () {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal1"), Input.GetAxisRaw("Vertical1"));
        Vector2 inputDir = input.normalized;

        if(inputDir != Vector2.zero)
        {
            float targetRotation =( Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg)-90;
            // subtract 90 because samurai plane007's rotation is not zero.

            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y,targetRotation,ref turnSmoothVelocity,turnSmoothTime);
          
        }

        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = (running ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        float animationSpeed = (running ? 1.0f : 0.5f) * inputDir.magnitude;
        animator.SetFloat("Speed", animationSpeed,speedSmoothTime,Time.deltaTime);
	}
}
