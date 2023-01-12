using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float maxVelocity;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float thrust;
    public float currentVelocity;
    private Rigidbody2D rb;

    [SerializeField]
    private bool constantSpeed = false;
    public float Rotation { get; set; }
    public float Thrust { get; set; }
    
    public float Velocity => rb.velocity.magnitude;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currentVelocity = Velocity;
    }

    public void ApplyRotation(float rotation)
    {
        
    }
    private void FixedUpdate()
    {
        rb.angularVelocity = - Rotation * rotationSpeed;
        
        if (constantSpeed)
        {
            rb.velocity = transform.up * maxVelocity;
        }
        else
        {
            rb.AddForce(Thrust*thrust*transform.up);
            rb.velocity = (rb.velocity.sqrMagnitude >= maxVelocity * maxVelocity)
                ? rb.velocity.normalized * maxVelocity
                : rb.velocity;    
        }
       
    }

    public void Warp(Vector2 destination)
    {
        rb.MovePosition(destination);
    }
    
}
