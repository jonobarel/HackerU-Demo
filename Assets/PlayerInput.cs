using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private Movement movement;
    
    void Awake()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movement.Thrust = verticalInput;
        movement.Rotation = horizontalInput;
    }
    
    
}
