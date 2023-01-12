using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController character;
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float jumpSpeed;
    private float gravity = -9.8f;
    
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 movementVector = verticalInput * walkingSpeed * Time.deltaTime * Vector3.forward;
        movementVector += horizontalInput * walkingSpeed * Time.deltaTime * Vector3.right;
        
        character.Move(movementVector);
        //transform.Rotate(Vector3.up * turnSpeed * horizontalInput*Time.deltaTime);
        
        if (!character.isGrounded)
        {
            character.Move(gravity * Time.deltaTime * Vector3.up);
        }
    }
}
