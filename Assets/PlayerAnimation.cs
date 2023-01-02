using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PlayerMovement player;
    private bool isFacingLeft;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        
        anim.SetBool("isGrounded", player.isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        if ((isFacingLeft && rb.velocity.x > 0.1f) || (!isFacingLeft && rb.velocity.x < -0.1f))
        {
            isFacingLeft = !isFacingLeft;
            anim.SetBool("isFlip", isFacingLeft);
        }
        
    }
}
