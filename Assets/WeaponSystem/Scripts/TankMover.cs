﻿using UnityEngine;

public class TankMover : MonoBehaviour
{

    public float Speed = 20;
    public float TurnSpeed = 100;

    void Start()
    {

    }

    void Update()
    {
        this.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal1") * TurnSpeed * Time.deltaTime, 0));
        this.transform.position += this.transform.forward * Input.GetAxis("Vertical1") * Speed * Time.deltaTime;
    }
}
